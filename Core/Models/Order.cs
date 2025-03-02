namespace Core.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TotalAmount { get; set; }
        public string? ShippingAddress { get; set; }
        public string? PaymentMethod { get; set; }
    }
}
