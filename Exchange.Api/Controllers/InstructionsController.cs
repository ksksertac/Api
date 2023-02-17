using Exchange.Models.Api.Dtos;
using Exchange.Api.Services;
using Fop;
using Microsoft.AspNetCore.Mvc;
using Exchange.Api.ControllerBases;
using Microsoft.AspNetCore.Authorization;

namespace Exchange.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/exchanges/{coin}/instructions")]
    public class InstructionsController : CustomBaseController
    {
        private readonly IInstructionService _instructionService;

        public InstructionsController(IInstructionService instructionService)
        {
            _instructionService = instructionService;
        }

        /// <summary>
        /// Retrieves instructions
        /// </summary>
        /// <param name="userId">user Id</param>
        /// <param name="request">Filter</param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/users/1/instructions?pageNumber=1&pageSize=10&order=createdDate;asc
        ///
        /// </remarks>
        /// <response code="20O">instruction list</response>
        /// <response code="404">If instruction does not exist</response>
        [HttpGet("/api/v1/users/{userId}/instructions")]
        public async Task<IActionResult> GetList([FromQuery] FopQuery request,long userId)
        {
            var response = await _instructionService.GetAllAsync(userId,request);
            return base.CreateActionResultInstance(response);
        }

        /// <summary>
        /// Retrieves a active instruction
        /// </summary>
        /// <param name="userId">user Id</param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/users/1/instructions/active
        ///
        /// </remarks>
        /// <response code="200">If there is a record</response>
        /// <response code="404">If record does not exist</response>
        [HttpGet("/api/v1/users/{userId}/instructions/active")]
        public async Task<IActionResult> GetActive(long userId)
        {
            var response = await _instructionService.GetActive(userId);
            return CreateActionResultInstance(response);
        }

        /// <summary>
        /// Creates a Book.
        /// </summary>
        /// <param name="userId">user Id</param>
        /// <param name="model">Instruction</param>
        /// <returns>A newly created Instruction</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/v1/users/1/instructions
        ///     {
        ///         "coin": "btc",
        ///         "amount": 240
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Record was created</response>
        /// <response code="400">If the record is null</response>
        /// <response code="404">If The record does not exist</response>
        [HttpPost("/api/v1/users/{userId}/instructions")]
        public async Task<IActionResult> Post(long userId, InstructionCreateDto model)
        {
            var response = await _instructionService.CreateAsync(userId,model);
            return CreateActionResultInstance(response);
        }


        /// <summary>
        /// Delete a instruction.
        /// </summary>
        /// <param name="userId">Coin</param>
        /// <param name="instructionId">Instruction Id</param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/v1/users/1/instructions/4
        ///
        /// </remarks>
        /// <response code="204">Record was deleted</response>
        /// <response code="404">If the instruction does not exist</response>
        [HttpDelete("/api/v1/users/{userId}/instructions/{instructionId}")]
        public async Task<IActionResult> Delete(long userId,long instructionId)
        {
            var response = await _instructionService.CancelAsync(instructionId,userId);
            return CreateActionResultInstance(response);
        }


    }
}