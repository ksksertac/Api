using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Exchange.Api.Models;

namespace Exchange.Api.Test.Mock.Entities
{
    public partial class ExchangeDbContextMock : ExchangeDb
    {
        private string _conn = "";
        public ExchangeDbContextMock(string conn) : base(conn)
        {
            _conn = conn;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_conn);
            }
        }
       
    }
}