export class CartItem {
  id: number;
  productId?: number;
  brandId: number;
  title?: string;
  model?: string;
  price: number;
  imageUrls?: string;
  brandName?: string;
  brandCountry?: string;
  quantity: number;
  totalAmount: number;
}
