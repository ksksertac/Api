using System.ComponentModel.DataAnnotations;

namespace Order.Api.Application.Models
{
    public class OrderDto
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}