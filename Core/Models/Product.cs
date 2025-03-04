namespace Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string? Title { get; set; }
        public string? Model { get; set; }
        public int Price { get; set; }
        public string? ImageUrls { get; set; }

    }
}
