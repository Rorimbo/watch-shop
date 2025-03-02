namespace Core.Models
{
    public class ProductWithBrand
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string? Title { get; set; }
        public int Price { get; set; }
        public string? ImageUrls { get; set; }

        public string? NameBrand { get; set; }
        public string? NameModel { get; set; }
    }
}
