namespace Core.Models.DTO
{
    public class ProductWithBrand : Product
    {
        public int? Id { get; set; }
        public int? BrandId { get; set; }
        public string? BrandName { get; set; }
        public string? BrandCountry { get; set; }

        public List<string>? ImageUrls { get; set; }
    }
}
