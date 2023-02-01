using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exchange.Models.Api.Dtos;
using Xunit;

namespace Exchange.Api.Test.Theory
{
    public class InstructionTheoryData : TheoryData<InstructionCreateDto>
    {
        public InstructionTheoryData()
        {
            Add(new InstructionCreateDto()
            {
                Coin = "btc",
                Amount = 200,
                SmsAllow = false,
                EmailAllow = false,
                PushAllow = true
            });
        }
    }
}