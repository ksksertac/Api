using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Exchange.Api.Models.Entities;

namespace Exchange.Api.Models
{
    public class Instruction
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long CoinId { get; set; }
        [Required]
        public long UserId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        /// <summary>
        /// 0 : Pasif
        /// 1 : Akitf
        /// 2 : Tamamlandı
        /// </summary>       
        [Required]
        public int Status { get; set; }
        public bool? SmsAllow { get; set; }
        public string? SmsMessage { get; set; }
        public DateTime? SmsDate { get; set; }
        public bool? EmailAllow { get; set; }
         public string? EmailMessage { get; set; }
        public DateTime? EmailDate { get; set; }
        public bool? PushAllow { get; set; }
        public string? PushMessage { get; set; }
        public DateTime? PushDate { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("CoinId")]
        public virtual Coin Coin { get; set; }
    }
}