using Microsoft.AspNetCore.Mvc;
using Xunit;
using Exchange.Api.Test.Fixture;
using Exchange.Api.Controllers;
using Exchange.Api.Models;
using Fop;
using Exchange.Api.Test.Theory;
using Exchange.Models.Api.Dtos;

namespace Exchange.Api.Test.Controllers
{
    public class InstructionsControllerTest : IClassFixture<ControllerFixture>
    {
        InstructionsController _controller;
        ExchangeDb context;

        public InstructionsControllerTest(ControllerFixture fixture)
        {
            _controller = fixture.instructionsController;
        }


        [Fact]
        public void GetActiveInstruction_WithoutParam_ThenOkObjectResult_Test()
        {
            var result = _controller.Get(1).Result as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
        }

        [Theory,InlineData(-1)]
        public void GetActiveInstruction_WithNonActiveInstructio_ThenNotFoundResult_Test(int userId)
        {
            var result = _controller.Get(userId).Result as NotFoundResult;
            Assert.Equal(404, result.StatusCode);
        }

        [Theory,InlineData("btc",1)]
        public void GetInstructionList_WithParamData_ThenOkObjectResult_Test(string coin,int userId)
        {
            FopQuery request = new FopQuery();
            request.Order = "id;asc";
            request.PageNumber = 1;
            request.PageSize = 10;

            var result = _controller.GetList(coin,request,userId).Result as OkObjectResult;
            Assert.Equal(200, result.StatusCode);
        }

        [Theory,ClassData(typeof(InstructionTheoryData))]
        public void AddInstructionWithTestData_ThenCreatedAtActionResult_Test(string coin,InstructionCreateDto dto,long userId)
        {
            var result = _controller.Post("btc",dto,1).Result as CreatedAtActionResult;
            Assert.Equal(201, result.StatusCode);
        }

        [Theory,InlineData("btc",-2,1)]
        public void CancelInstruction_WithNonInstruction_ThenNotFound_Test(string coin,long id,long userId)
        {
            var result = _controller.Delete(coin,id,userId).Result as NotFoundResult;
            Assert.Equal(404, result.StatusCode);
        }

        [Theory,InlineData("btc",1,1)]
        public void CancelInstruction_ThenNoContentResult_Test(string coin,long id,long userId)
        {
            
            var result = _controller.Delete(coin,id,userId).Result as NoContentResult;
            Assert.Equal(404, result.StatusCode);
        }

    }
}