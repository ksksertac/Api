using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Exchange.Api.Models.Entities;

namespace Exchange.Api.Models.Entities
{
    public class NotificationTemplate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Type { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string TemplateTitle { get; set; }
        [Required]
        public string TemplateText { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}