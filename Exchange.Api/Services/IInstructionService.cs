using Exchange.Models.Api.Dtos;
using Exchange.Api.Models;
using Fop;

namespace Exchange.Api.Services
{
    public interface IInstructionService
    {
        Task<Response<InstructionDto>> GetActive(long userId);
        Task<Response<InstructionDto>> GetById(long id);
        Task<Response<List<InstructionDto>>> GetAllAsync(string coin, long userId,FopQuery filter);
        Task<Response<InstructionDto>> CreateAsync(string coin,long userId,InstructionCreateDto model);
        Task<Response<NoContent>> CancelAsync(long id ,long userId);
        Task<Response<NoContent>> UpdateAsync(InstructionDto model);
    }
}