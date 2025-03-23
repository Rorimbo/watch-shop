import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cart } from 'src/app/types/cart';
import { Item } from 'src/app/types/Item';
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

  getInfoProduct(id: number): Observable<Item> {
    return this.http.get<Item>(`https://localhost:7133/products/info/${id}`);
  }

  updateCart(cart: Cart): Observable<void> {
    return this.http.post<void>(`https://localhost:7133/orders/cart`, cart);
  }

  searchByBrand(brand: string): Observable<Product[]> {
    return this.http.get<Product[]>(
      `https://localhost:7133/products/search/${brand}`
    );
  }
}
