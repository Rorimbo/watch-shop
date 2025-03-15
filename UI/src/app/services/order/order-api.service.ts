import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CartItem } from 'src/app/types/CartItem';

@Injectable({
  providedIn: 'root',
})
export class OrderApiService {
  http = inject(HttpClient);

  constructor() {}

  getCart(userId: number): Observable<CartItem[]> {
    return this.http.get<CartItem[]>(
      `https://localhost:7133/orders/cart/${userId}`
    );
  }
}
