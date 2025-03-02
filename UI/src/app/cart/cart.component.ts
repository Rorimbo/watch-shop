import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CartItem } from '../Types/CartItem';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
})
export class CartComponent {
  cartItems: CartItem[];
  total: number = 0;

  delete(item: CartItem) {
    this.cartItems.forEach((el, i) => {
      if (el == item) {
        this.cartItems.splice(i, 1);
      }
    });
  }
}
