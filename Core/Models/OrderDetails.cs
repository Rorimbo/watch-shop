namespace Core.Models
{
    public class OrderDetails
    {
        public List<CartForView> Cart { get; set; }
        public int UserId { get; set; }
        public int TotalAmount { get; set; }
        public string? ShippingAddress { get; set; }
        public string? PaymentMethod { get; set; }
    }
}
