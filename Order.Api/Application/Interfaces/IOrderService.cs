using Order.Api.Infrastructure.Api;
using Order.Api.Application.Models;
using Fop;

namespace Order.Api.Application.Interfaces
{
    public interface IOrderService
    {
        Task<Response<OrderDto>> GetById(long id);
        Task<Response<List<OrderDto>>> GetAllAsync(long userId,FopQuery filter);
        Task<Response<OrderDto>> CreateAsync(long userId,OrderCreateDto model);
        Task<Response<NoContent>> CancelAsync(long id ,long userId);
        Task<Response<NoContent>> UpdateAsync(OrderDto model);
    }
}