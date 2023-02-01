using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Exchange.Models.Api.Dtos
{
    public class InstructionCreateDto
    {
        [Required]
        public string Coin { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }
}