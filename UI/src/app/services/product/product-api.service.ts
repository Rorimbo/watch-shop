import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Products } from 'src/app/types/Products';
import { ProductsWithBrands } from 'src/app/types/ProductsWithBrands';

@Injectable({
  providedIn: 'root',
})
export class ProductApiService {
  http = inject(HttpClient);

  constructor() {}

  getAllProducts(): Observable<ProductsWithBrands[]> {
    return this.http.get<ProductsWithBrands[]>(
      `http://localhost:7133/products/all`
    );
  }
}
