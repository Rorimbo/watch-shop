namespace Core.Models.DTO
{
    public class CartDto
    {
        public int TotalAmount { get; set; }

        public List<CartItem> CartItems { get; set; }
    }
}
