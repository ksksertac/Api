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

        [Theory,ClassData(typeof(InstructionTheoryData))]
        public void GetActiveInstruction_ThenDataTotalCountGreaterThanZero_Test(InstructionCreateDto dto)
        {
            var activeIntruction = _service.GetActive(1).Result;
            if(!activeIntruction.IsSuccessful)
            {
                var re = _service.CreateAsync(1,dto).Result;
            }
            var data = _service.GetActive(1).Result;
            Assert.Equal(true, data.DataTotalCount>0);
        }

        [Fact]
        public void GetInstructionList_WithSortData_ThenDataTotalCountGreaterThanZero_Test()
        {
            FopQuery request = new FopQuery();
            request.Order = "id;asc";
            request.PageNumber = 1;
            request.PageSize = 10;

            var data = _service.GetAllAsync(1,request).Result;
            Assert.Equal(true, data.DataTotalCount>0);
        }

        [Theory,ClassData(typeof(InstructionTheoryData))]
        public void AddInstructionWithTestData_ThenSuccessfulResult_Test(InstructionCreateDto dto)
        {
            var activeIntruction = _service.GetActive(1).Result;
            if(activeIntruction.IsSuccessful)
            {
                var re =  _service.CancelAsync(activeIntruction.Data.Id,1).Result;
            }
            var result = _service.CreateAsync(1,dto).Result;
            Assert.Equal(true, result.IsSuccessful);
        }

        [Theory,InlineData(-2,1)]
        public void CancelInstruction_WithNonInstruction_ThenNotSuccessfulResult_Test(long id,long userId)
        {
            var result = _service.CancelAsync(id,userId).Result;
            Assert.Equal(false, result.IsSuccessful);
        }

        [Theory,ClassData(typeof(InstructionTheoryData))]
        public void CancelInstruction_ThenSuccessfulResult_Test(InstructionCreateDto dto)
        {
            long id = 1;
            var activeIntruction = _service.GetActive(1).Result;
            if(!activeIntruction.IsSuccessful)
                id = _service.CreateAsync(1,dto).Result.Data.Id;
            else
                id = activeIntruction.Data.Id;

            var result = _service.CancelAsync(id,1).Result;
            Assert.Equal(true, result.IsSuccessful);
        }

    }
}