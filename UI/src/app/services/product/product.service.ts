import { inject, Injectable } from '@angular/core';
import { ProductApiService } from '../product/product-api.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { catchError, Observable, throwError } from 'rxjs';
import { Products } from 'src/app/types/Products';
import { ProductsWithBrands } from 'src/app/types/ProductsWithBrands';

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

  getAllProducts(): Observable<ProductsWithBrands[]> {
    return this.productApiService.getAllProducts().pipe(
      catchError((err) => {
        this.openSnackBar('Ошибка получения данных');
        return throwError(err);
      })
    );
  }
}
