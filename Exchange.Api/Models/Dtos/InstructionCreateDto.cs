using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Exchange.Models.Api.Dtos
{
    public class InstructionCreateDto
    {
        [Required]
        public decimal Amount { get; set; }
        public bool? SmsAllow { get; set; }
        public bool? EmailAllow { get; set; }
        public bool? PushAllow { get; set; }
    }
}