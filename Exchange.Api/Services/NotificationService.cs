using AutoMapper;
using Exchange.Api.Models;
using Exchange.Api.Models.Dtos;
using Exchange.Models.Api.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Exchange.Api.Services
{
    public class NotificationService : INotificationService
    { 
        private readonly ILogger<NotificationService> _logger;
        private IMapper _mapper { get; }
        private readonly ExchangeDb _dbContext;
        public NotificationService(ILogger<NotificationService> logger, ExchangeDb dbContext, IMapper mapper)
        {
            _logger = logger;
            _dbContext = dbContext;
            _mapper = mapper;
        }
        /// <summary>
        /// Aktif bildirim teması döner
        /// Tip  : 1  InstructionCompleteEmail
        /// Tip  : 2  InstructionCompleteSms
        /// Tip  : 3  InstructionCompletePush
        /// </summary>       
        public async Task<Response<NotificationTemplateDto>> GetActive(int type)
        {
            var data = await _dbContext.NotificationTemplates.FirstOrDefaultAsync(x => x.Type == type && x.IsActive);
            if (data == null)
            {
                return Response<NotificationTemplateDto>.Fail("NotificationTemplate not found", 404);
            }
            return Response<NotificationTemplateDto>.Success(_mapper.Map<NotificationTemplateDto>(data), 200);
        }

        /// <summary>
        /// Call Email api
        /// </summary>       
        public async Task<Response<NoContent>> SendEmailAsync(string receive, string title, string body)
        {
            return Response<NoContent>.Success(new NoContent(), 200);
        }

        /// <summary>
        /// Call sms api
        /// </summary>       
        public async Task<Response<NoContent>> SendSmsAsync(string phone, string title, string body)
        {
            return Response<NoContent>.Success(new NoContent(), 200);
        }

        /// <summary>
        /// Call push api
        /// </summary>       
        public async Task<Response<NoContent>> SendPushAsync(string deviceId, string title, string body)
        {
            return Response<NoContent>.Success(new NoContent(), 200);
        }
    }
}