using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Order.Api.Infrastructure.Api;
using Order.Api.Application.Models;
using Order.Api.Application.Interfaces;
using Order.Api.Application.Services;
using Order.Api.Application.Models;
using Fop;
namespace Order.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/orders")]
    public class OrdersController : CustomBaseController
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IOrderService _service;

        public OrdersController(ILogger<OrdersController> logger
        ,IOrderService service
        )
        {
            _logger = logger;
            _service = service;
        }

         /// <summary>
        /// Retrieves orders
        /// </summary>
        /// <param name="userId">user Id</param>
        /// <param name="request">Filter</param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/orders?pageNumber=1&pageSize=10&order=createdDate;asc
        ///
        /// </remarks>
        /// <response code="20O">order list</response>
        /// <response code="404">If order does not exist</response>
        [HttpGet()]
        public async Task<IActionResult> GetList([FromQuery] FopQuery request,long userId)
        {
            var response = await _service.GetAllAsync(userId,request);
            return base.CreateActionResultInstance(response);
        }

        
    }
}