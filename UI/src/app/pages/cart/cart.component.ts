import { Component } from '@angular/core';
import { CartItem } from '../../types/CartItem';
import { OrderService } from 'src/app/services/order/order.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
})
export class CartComponent {
  cartItems: CartItem[];
  total: number = 0;

  constructor(public orderService: OrderService) {}

  ngOnInit() {
    this.orderService.getCart(1).subscribe((cartItems) => {
      this.cartItems = cartItems;
    });
  }

  delete(item: CartItem) {
    this.cartItems.forEach((el, i) => {
      if (el == item) {
        this.cartItems.splice(i, 1);
      }
    });
  }
}
