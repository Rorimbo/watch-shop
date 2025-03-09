namespace Core.Models
{
    public class CartForView: ProductWithBrand
    {
        public int Quantity { get; set; }
        public int TotalAmount { get; set; }
    }
}
