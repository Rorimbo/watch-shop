namespace Core.Models
{
    public class ProductWithBrand : Product
    {
        public int? Id { get; set; }
        public int? BrandId { get; set; }
        public string? BrandName { get; set; }
        public string? BrandCountry { get; set; }
    }
}
