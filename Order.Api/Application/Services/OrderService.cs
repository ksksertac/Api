using Order.Api.Infrastructure.Api;
using Order.Api.Application.Models;
using Order.Api.Application.Interfaces;
using Fop;

namespace Order.Api.Application.Services
{
    public class OrderService : IOrderService
    {
        public OrderService()
        {
        }

        public async Task<Response<OrderDto>> GetById(long id)
        {
            return null;
        }
        public async Task<Response<List<OrderDto>>> GetAllAsync(long userId, FopQuery filter)
        {
            return null;
        }
        public async Task<Response<OrderDto>> CreateAsync(long userId, OrderCreateDto model)
        {
            return null;
        }
        public async Task<Response<NoContent>> CancelAsync(long id, long userId)
        {
            return null;
        }
        public async Task<Response<NoContent>> UpdateAsync(OrderDto model)
        {
            return null;
        }
    }
}