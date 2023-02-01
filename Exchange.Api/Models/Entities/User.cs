using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exchange.Api.Models.Entities
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string NameSurname { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public string DeviceId { get; set; }

        [Required]
        public decimal MinInstructionAmount { get; set; }
        [Required]
        public decimal MaxInstructionAmount { get; set; }

        [Required]
        public int StartOfInstructionDay { get; set; }
        [Required]
        public int EndOfInstructionDay { get; set; }

        public bool? SmsAllow { get; set; }
        public bool? EmailAllow { get; set; }
        public bool? PushAllow { get; set; }

        [Required]
        public bool IsActive { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}