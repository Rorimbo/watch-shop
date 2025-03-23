namespace Core.Models.DTO
{
    public class OrderDetails
    {
        public List<CartItem> Cart { get; set; }
        public int UserId { get; set; }
        public int TotalAmount { get; set; }
        public string? ShippingAddress { get; set; }
        public string? PaymentMethod { get; set; }
    }
}
