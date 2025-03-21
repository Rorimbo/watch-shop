import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cart } from 'src/app/types/cart';
import { Product } from 'src/app/types/product';

@Injectable({
  providedIn: 'root',
})
export class ProductApiService {
  http = inject(HttpClient);

  constructor() {}

  getAllProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(`https://localhost:7133/products/all`);
  }

  getProductId(id: number): Observable<Product[]> {
    return this.http.get<Product[]>(`https://localhost:7133/products/info/${id}`);
  }

  updateCart(cart: Cart): Observable<void> {
    return this.http.post<void>(`https://localhost:7133/orders/cart`, cart);
  }
}
