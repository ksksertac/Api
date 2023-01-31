using Exchange.Models.Api.Dtos;
using Exchange.Api.Services;
using Fop;
using Microsoft.AspNetCore.Mvc;
using Exchange.Api.ControllerBases;

namespace Exchange.Api.Controllers
{
    [Route("api/v1/exchanges/{coin}/instructions")]
    [ApiController]
    public class InstructionsController : CustomBaseController
    {
        private readonly ILogger<InstructionsController> _logger;
        private readonly IInstructionService _instructionService;

        public InstructionsController(ILogger<InstructionsController> logger, IInstructionService instructionService)
        {
            _logger = logger;
            _instructionService = instructionService;
        }

        /// <summary>
        /// Retrieves instructions
        /// </summary>
        /// <param name="coin">Coin</param>
        /// <param name="request">Filter</param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /exchanges/btc/instructions?pageNumber=1&pageSize=10&order=createdDate;asc
        ///
        /// </remarks>
        /// <response code="20O">instruction list</response>
        /// <response code="404">If instruction does not exist</response>
        [HttpGet]
        public async Task<IActionResult> GetList(string coin, [FromQuery] FopQuery request,[FromHeader] long userId)
        {
            var response = await _instructionService.GetAllAsync(coin,userId,request);
            return base.CreateActionResultInstance(response);
        }

        /// <summary>
        /// Retrieves a specific instruction
        /// </summary>
        /// <param name="coin">Coin</param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /exchanges/btc/instructions
        ///
        /// </remarks>
        /// <response code="200">If there is a record</response>
        /// <response code="404">If record does not exist</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string coin,[FromHeader] long userId)
        {
            var response = await _instructionService.GetActive(userId);
            return CreateActionResultInstance(response);
        }

        /// <summary>
        /// Creates a Book.
        /// </summary>
        /// <param name="coin">Coin</param>
        /// <param name="InstructionDto">Instruction</param>
        /// <returns>A newly created Instruction</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /exchanges/btc/instructions
        ///     {
        ///         "isbn": "AA-11-23-1",
        ///         "name": ".Net Core 3.1",
        ///         "authorId": 3
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Record was created</response>
        /// <response code="400">If the record is null</response>
        /// <response code="404">If The record does not exist</response>
        [HttpPost]
        public async Task<IActionResult>  Post(string coin, InstructionDto model,[FromHeader] long userId)
        {
            //long userId,InstructionDto model
            var response = await _instructionService.CreateAsync(userId,model);
            return CreateActionResultInstance(response);
        }


        /// <summary>
        /// Delete a instruction.
        /// </summary>
        /// <param name="coin">Coin</param>
        /// <param name="id">Instruction Id</param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /exchanges/btc/instructions/3
        ///
        /// </remarks>
        /// <response code="204">Record was deleted</response>
        /// <response code="404">If the instruction does not exist</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string coin, int id,[FromHeader] long userId)
        {
            var response = await _instructionService.CancelAsync(id,userId);
            return CreateActionResultInstance(response);
        }


    }
}