import { inject, Injectable } from '@angular/core';
import { ProductApiService } from '../product/product-api.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { catchError, Observable, throwError } from 'rxjs';
import { Product } from 'src/app/types/product';
import { Cart } from 'src/app/types/cart';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  constructor(private productApiService: ProductApiService) {}
  private _snackBar = inject(MatSnackBar);

  openSnackBar(message: string) {
    this._snackBar.open(message, 'Закрыть', {
      horizontalPosition: 'end',
      verticalPosition: 'top',
      duration: 10000,
    });
  }

  getAllProducts(): Observable<Product[]> {
    return this.productApiService.getAllProducts().pipe(
      catchError((err) => {
        this.openSnackBar('Ошибка получения данных');
        return throwError(err);
      })
    );
  }

  getProductId(id: number): Observable<Product[]>{
    return this.productApiService.getProductId(id).pipe(
      catchError((err) => {
        this.openSnackBar('Ошибка получения данных');
        return throwError(err);
      })
    );
  }

  updateCart(productId: number, quantity: number): Observable<void> {
    let cart: Cart = {
      productId: productId,
      userId: 1,
      quantity: quantity,
    };

    return this.productApiService.updateCart(cart).pipe(
      catchError((err) => {
        this.openSnackBar('Ошибка добавления в корзину');
        return throwError(err);
      })
    );
  }
}
