import { Component } from '@angular/core';
import { CartComponent } from './pages/cart/cart.component';
import { ModelComponent } from './pages/model/model.component';
import { CartItem } from './types/cart-item';

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
          this.total += el.totalAmount;
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
