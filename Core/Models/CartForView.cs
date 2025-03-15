namespace Core.Models
{
    public class CartForView
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int BrandId { get; set; }
        public string? Title { get; set; }
        public string? Model { get; set; }
        public int Price { get; set; }
        public string? ImageUrls { get; set; }
        public string? BrandName { get; set; }
        public string? BrandCountry { get; set; }
        public int Quantity { get; set; }
        public int TotalAmount { get; set; }
    }
}
