import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CartItem } from 'src/app/types/cart-item';
import { Cart } from 'src/app/types/cart';

@Injectable({
  providedIn: 'root',
})
export class OrderApiService {
  http = inject(HttpClient);

  constructor() {}

  addCart(cart: Cart): Observable<Cart[]> {
    return this.http.post<Cart[]>(`https://localhost:7133/orders/cart`, cart);
  }

  getCart(userId: number): Observable<CartItem[]> {
    return this.http.get<CartItem[]>(
      `https://localhost:7133/orders/cart/${userId}`
    );
  }
}
