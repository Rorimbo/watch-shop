import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cart } from 'src/app/types/cart';
import { CartItem } from 'src/app/types/cart-item';
import { OrderDetails } from 'src/app/types/order-details';

@Injectable({
  providedIn: 'root',
})
export class OrderApiService {
  http = inject(HttpClient);

  constructor() {}

  addToCart(cart: Cart): Observable<Cart[]> {
    return this.http.post<Cart[]>(`https://localhost:7133/orders/cart`, cart);
  }

  getCart(userId: number): Observable<CartItem[]> {
    return this.http.get<CartItem[]>(
      `https://localhost:7133/orders/cart/${userId}`
    );
  }

  createOrder(orderDetails: OrderDetails): Observable<number> {
    return this.http.post<number>(
      `https://localhost:7133/orders/order`,
      orderDetails
    );
  }
}
