using AutoMapper;
using Exchange.Models.Api.Dtos;
using Exchange.Api.Models;
using Fop;
using Mass = MassTransit;
using Microsoft.EntityFrameworkCore;
using Fop.FopExpression;
using Exchange.Api.Events;

namespace Exchange.Api.Services
{
    public class InstructionService : IInstructionService
    {
        private IMapper _mapper { get; }
        private readonly ExchangeDb _dbContext;

        private readonly Mass.IPublishEndpoint _publishEndpoint;

        public InstructionService(ExchangeDb dbContext, IMapper mapper, Mass.IPublishEndpoint publishEndpoint)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        /// <summary>
        /// Talep iptal
        /// Kullanıcı talimatını iptal edebilir.
        /// </summary>       
        public async Task<Response<NoContent>> CancelAsync(long id, long userId)
        {
            var userData = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId && x.IsActive);
            if (userData == null)
                return Response<NoContent>.Fail("User not found", 404);

            var data = await _dbContext.Instructions.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId && x.Status>0);
            if(data == null)
                return Response<NoContent>.Fail("Instruction not found", 404);
            data.Status = 0;
            await _dbContext.SaveChangesAsync();
            return Response<NoContent>.Success(204);
        }

        /// <summary>
        /// Aktif talimat
        /// Kullanıcı aktif talimatını görüntüleyebilir.
        /// Kullanıcı aktif talimatına ait bildirim kanallarını listeleyebilir.
        /// </summary>       
        public async Task<Response<InstructionDto>> GetActive(long userId)
        {
            var userData = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId && x.IsActive);
            if (userData == null)
                return Response<InstructionDto>.Fail("User not found", 404);

            var data = await _dbContext.Instructions.OrderByDescending(x=>x.Id).FirstOrDefaultAsync(x => x.UserId == userId && x.Status == 1);
            if (data == null)
            {
                return Response<InstructionDto>.Fail("Instruction not found", 404);
            }
            return Response<InstructionDto>.Success(_mapper.Map<InstructionDto>(data),1, 200);
        }

        /// <summary>
        /// Id'ye göre talebi verir.
        /// </summary>       
        public async Task<Response<InstructionDto>> GetById(long id)
        {
            var data = await _dbContext.Instructions.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
            {
                return Response<InstructionDto>.Fail("Instruction not found", 404);
            }
            return Response<InstructionDto>.Success(_mapper.Map<InstructionDto>(data),1, 200);
        }

        /// <summary>
        /// Tüm Talimat listesi
        /// </summary>       
        public async Task<Response<List<InstructionDto>>> GetAllAsync(long userId, FopQuery filter)
        {
            var userData = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId && x.IsActive);
            if (userData == null)
                return Response<List<InstructionDto>>.Fail("User not found", 404);

            var fopRequest = FopExpressionBuilder<Instruction>.Build(filter.Filter, filter.Order, filter.PageNumber, filter.PageSize);
            var (data, totalDataCount) = _dbContext.Instructions.Where(x => x.UserId == userId).ApplyFop(fopRequest);
            if (data == null)
            {
                return Response<List<InstructionDto>>.Fail("Instruction not found", 404);
            }
            return Response<List<InstructionDto>>.Success(_mapper.Map<List<InstructionDto>>(data), totalDataCount, 200);
        }

        /// <summary>
        /// Talimat kayıt.
        /// Kullanıcı ayın 1-28 günleri arası için talimat verebilir.
        /// Kullanıcı minimum 100 TL’lik maksimum 20.000 TL’lik talimat verebilir
        /// Bir kullanıcıya ait sadece 1 tane aktif talimat olabilir.
        /// Kullanıcı hangi kanallardan bilgilendirilmek istediğini seçmelidir. Kullanıcı birden fazla seçim yapabilir.
        /// Yapılan her bilgilendirme işlemi database seviyesinde loglanmalıdır. Hangi talimat için hangi kanaldan ne zaman hangi bilgilendirme yazısı ile yapıldı sorularına cevap verilebilmelidir.
        /// </summary>       
        public async Task<Response<InstructionDto>> CreateAsync(long userId, InstructionCreateDto model)
        {
            if (model == null)
                return Response<InstructionDto>.Fail("Instruction informations cannot be empty", 400);

            var coinData = await _dbContext.Coins.FirstOrDefaultAsync(x => x.ShortName == model.Coin && x.IsActive);
            if (coinData == null)
                return Response<InstructionDto>.Fail("Coin not found", 404);

            var userData = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId && x.IsActive);
            if (userData == null)
                return Response<InstructionDto>.Fail("User not found", 404);

            //Kullanıcı ayın 1-28 günleri arası için talimat verebilir.
            if (!Enumerable.Range(userData.StartOfInstructionDay ,userData.EndOfInstructionDay).Contains(DateTime.Now.Day))
            {
                return Response<InstructionDto>.Fail($"You can instruction from the {userData.StartOfInstructionDay}st to the {userData.EndOfInstructionDay}th of the month", 403);
            }
            //Kullanıcı minimum 100 TL’lik maksimum 20.000 TL’lik talimat verebilir
            if (!(userData.MinInstructionAmount <= model.Amount && model.Amount <= userData.MaxInstructionAmount))
            {
                return Response<InstructionDto>.Fail($"You can give instruction between {userData.MinInstructionAmount} TL and {userData.MaxInstructionAmount} TL", 403);
            }
            //Bir kullanıcıya ait sadece 1 tane aktif talimat olabilir.
            if (this.GetActive(userId).Result.Data != null)
                return Response<InstructionDto>.Fail($"You can only have 1 active instruction", 403);

            var data = new Instruction();
            data.Amount = model.Amount;
            data.UserId = userId;
            data.CoinId = coinData.Id;
            data.SmsAllow = userData.SmsAllow;
            data.EmailAllow = userData.EmailAllow;
            data.PushAllow = userData.PushAllow;
            data.CreatedDate = DateTime.Now;
            data.Status = 1; //Aktif
            await _dbContext.Instructions.AddAsync(data);
            await _dbContext.SaveChangesAsync();
            
            //Publish NotificationEvent
            if(_publishEndpoint != null)
                await _publishEndpoint.Publish<InstructionNotificationEvent>(new InstructionNotificationEvent { InstructionId = data.Id, UserNameSurName = userData.NameSurname, Email = userData.Email, Phone = userData.Phone, DeviceId = userData.DeviceId });

            return Response<InstructionDto>.Success(_mapper.Map<InstructionDto>(data),1, 201);
        }



        /// <summary>
        ///  Talimat güncelle
        ///  Talimat başarılı bir şekilde verildikten sonra kullanıcı bildirim almak istediği kanaldan bilgilendirilmelidir. 
        ///  Bilgilendirme işlemi fake-api request ile gerçekleştirilebilir. Burada bir implementasyon beklenmemektedir.
        /// </summary>       
        public async Task<Response<NoContent>> UpdateAsync(InstructionDto model)
        {
            var result = await _dbContext.Instructions.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (result == null)
            {
                return Response<NoContent>.Fail("Instruction not found", 404);
            }
            var data = _mapper.Map<Instruction>(model);
            data.CoinId = result.CoinId;
            _dbContext.ChangeTracker.Clear();
            _dbContext.Instructions.Update(data);
            _dbContext.SaveChanges();
            return Response<NoContent>.Success(200);
        }

    }
}