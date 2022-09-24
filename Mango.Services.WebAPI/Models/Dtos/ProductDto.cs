namespace Mango.Services.WebAPI.Models.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public double Price;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}