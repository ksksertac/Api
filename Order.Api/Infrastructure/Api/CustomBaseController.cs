using Microsoft.AspNetCore.Mvc;
using Order.Api.Application.Models;

namespace Order.Api.Infrastructure.Api
{
     public class CustomBaseController : ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}