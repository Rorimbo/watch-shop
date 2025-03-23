import { Component } from '@angular/core';
import { CartItem } from '../../types/cart-item';
import { OrderService } from 'src/app/services/order/order.service';
import { ProductService } from 'src/app/services/product/product.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
})
export class CartComponent {
  cartItems: CartItem[];
  totalAmount: number = 0;
  showTooltip: boolean = false;

  constructor(
    public orderService: OrderService,
    public productService: ProductService
  ) {}

  ngOnInit() {
    this.orderService.getCart(1).subscribe((cartItems) => {
      this.cartItems = cartItems;
    });
  }

  removeFromCart(cartitem: CartItem) {
    this.productService.updateCart(cartitem.productId!, -1).subscribe(() => {
      cartitem.quantity -= 1;
      if (cartitem.quantity == 0) {
        this.delete(cartitem);
      }
    });
  }

  addToCart(cartitem: CartItem) {
    this.productService.updateCart(cartitem.productId!, 1).subscribe(() => {
      cartitem.quantity += 1;
    });
  }

  onOrderReady() {
    this.showTooltip = true;
    setTimeout(() => {
      this.showTooltip = false;
    }, 10000);
    this.cartItems = [];
  }

  delete(item: CartItem) {
    this.cartItems = this.cartItems.filter((el) => el !== item);
  }
}
