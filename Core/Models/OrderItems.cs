namespace Core.Models
{
    /// <summary>
    /// Товар из списка заказа.
    /// </summary>
    public class OrderItems
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

    }
}
