import { Component } from '@angular/core';
import { CartComponent } from './cart/cart.component';
import { ModelComponent } from './model/model.component';
import { CartItem } from './Types/CartItem';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  cartItems: CartItem[] = [];
  total: number = 0;

  constructor() {}

  ngOnInit(): void {}

  giveCart(component: any) {
    if (
      component instanceof CartComponent ||
      component instanceof ModelComponent
    ) {
      component.cartItems = this.cartItems;
      if (this.cartItems) {
        this.total = 0;
        this.cartItems.forEach((el) => {
          this.total += el.totalPrice;
        });
      }
      component.total = this.total;
    }
  }

  getCart(component: any) {
    if (
      component instanceof CartComponent ||
      component instanceof ModelComponent
    ) {
      this.cartItems = component.cartItems;
    }
  }
}
