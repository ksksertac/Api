using System.ComponentModel.DataAnnotations;

namespace Exchange.Api.Models.Entities
{
    public class Coin
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ShortName { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public decimal Price { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}