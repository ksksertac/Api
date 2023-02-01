using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Exchange.Api.Controllers;
using Exchange.Api.Helpers;
using Exchange.Api.Test.Mock.Entities;
using Exchange.Api.Services;

namespace Exchange.Api.Test.Fixture
{
    public class ControllerFixture : IDisposable
    {
        private ExchangeDbContextMock dbContextMock { get; set; }
        private IMapper mapper { get; set; }
        public InstructionsController _instructionsController { get; private set; }
        public IInstructionService _instructionsService { get; private set; }

        public ControllerFixture()
        {   
            // mock data created 
            dbContextMock = new ExchangeDbContextMock("Server=localhost;Database=ExchangeDb;User=sa;Password=MyPass@word;");


            #region Mapper settings with original profiles.

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            mapper = mappingConfig.CreateMapper();

            #endregion
            //Create Service
            _instructionsService = new InstructionService(dbContextMock,mapper,null);
            // Create Controller
            _instructionsController = new InstructionsController(_instructionsService);
           
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ControllerFixture()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContextMock.Dispose();
                dbContextMock = null;
                mapper = null;
                _instructionsController = null;
            }
        }
    }
}