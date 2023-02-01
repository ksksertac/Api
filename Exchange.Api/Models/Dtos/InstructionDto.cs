using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Exchange.Models.Api.Dtos
{
    public class InstructionDto
    {
        public long Id { get; set; }
        [Required]
        public long UserId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public int Status { get; set; }
        public bool? SmsAllow { get; set; }
        public string SmsMessage { get; set; }
        public DateTime? SmsDate { get; set; }
        public bool? EmailAllow { get; set; }
        public string EmailMessage { get; set; }
        public DateTime? EmailDate { get; set; }
        public bool? PushAllow { get; set; }
        public string PushMessage { get; set; }
        public DateTime? PushDate { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}