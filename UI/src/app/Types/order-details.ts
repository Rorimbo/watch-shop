import { CartItem } from './cart-item';

export class OrderDetails {
  cart: CartItem[];
  userId: number;
  totalAmount: number;
  shippingAddress?: string;
  paymentMethod?: string;
}
