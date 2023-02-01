using Microsoft.AspNetCore.Mvc;
using Xunit;
using Exchange.Api.Test.Fixture;
using Exchange.Api.Controllers;
using Exchange.Api.Models;
using Fop;
using Exchange.Api.Test.Theory;
using Exchange.Models.Api.Dtos;
using Exchange.Api.Services;

namespace Exchange.Api.Test.Controllers
{
    public class InstructionsControllerTest : IClassFixture<ControllerFixture>
    {
        InstructionsController _controller;
        IInstructionService _service;
        ExchangeDb context;

        public InstructionsControllerTest(ControllerFixture fixture)
        {
            _controller = fixture._instructionsController;
            _service = fixture._instructionsService;
        }


        [Fact]
        public void GetActiveInstruction_WithoutParam_ThenOkObjectResult_Test()
        {
            var result = _controller.GetActive(1).Result as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
        }

        [Theory,InlineData(-1)]
        public void GetActiveInstruction_WithNonActiveInstructio_ThenNotFoundResult_Test(int userId)
        {
            var result = _controller.GetActive(userId).Result as NotFoundResult;
            Assert.Equal(404, result.StatusCode);
        }

        [Theory,InlineData(1)]
        public void GetInstructionList_WithParamData_ThenOkObjectResult_Test(int userId)
        {
            FopQuery request = new FopQuery();
            request.Order = "id;asc";
            request.PageNumber = 1;
            request.PageSize = 10;

            var result = _controller.GetList(request,userId).Result as OkObjectResult;
            Assert.Equal(200, result.StatusCode);
        }

        [Theory,ClassData(typeof(InstructionTheoryData))]
        public void AddInstructionWithTestData_ThenCreatedAtActionResult_Test(InstructionCreateDto dto)
        {
            var result = _controller.Post(1,dto).Result as CreatedAtActionResult;
            Assert.Equal(201, result.StatusCode);
        }

        [Theory,InlineData(-2,1)]
        public void CancelInstruction_WithNonInstruction_ThenNotFound_Test(long id,long userId)
        {
            
            var result = _controller.Delete(id,userId).Result as NotFoundResult;
            Assert.Equal(404, result.StatusCode);
        }

        [Theory,ClassData(typeof(InstructionTheoryData))]
        public void CancelInstruction_ThenNoContentResult_Test(InstructionCreateDto dto)
        {
            long id = 0;
            var activeIntruction = _service.GetActive(1).Result;
            if(activeIntruction.Data == null)
            {
                id = _service.CreateAsync(1,dto).Result.Data.Id;
            }
            var result = _controller.Delete(1,id).Result as NoContentResult;
            Assert.Equal(404, result.StatusCode);
        }

    }
}