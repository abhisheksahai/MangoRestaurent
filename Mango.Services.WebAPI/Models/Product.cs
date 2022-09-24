using System.ComponentModel.DataAnnotations;

namespace Mango.Services.WebAPI.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Range(1, 1000)]
        public double Price;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}