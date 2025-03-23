import { inject, Injectable } from '@angular/core';
import { OrderApiService } from './order-api.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { catchError, Observable, throwError } from 'rxjs';
import { Cart } from 'src/app/types/cart';
import { CartItem } from 'src/app/types/cart-item';
import { OrderDetails } from 'src/app/types/order-details';

@Injectable({
  providedIn: 'root',
})
export class OrderService {
  constructor(private orderApiService: OrderApiService) {}
  private _snackBar = inject(MatSnackBar);

  openSnackBar(message: string) {
    this._snackBar.open(message, 'Закрыть', {
      horizontalPosition: 'end',
      verticalPosition: 'top',
      duration: 10000,
    });
  }

  addToCart(cart: Cart): Observable<Cart[]> {
    return this.orderApiService.addToCart(cart).pipe(
      catchError((err) => {
        this.openSnackBar('Ошибка получения данных');
        return throwError(err);
      })
    );
  }

  getCart(userId: number): Observable<CartItem[]> {
    return this.orderApiService.getCart(userId).pipe(
      catchError((err) => {
        this.openSnackBar('Ошибка получения данных');
        return throwError(err);
      })
    );
  }

  createOrder(orderDetails: OrderDetails): Observable<number> {
    return this.orderApiService.createOrder(orderDetails).pipe(
      catchError((err) => {
        this.openSnackBar('Ошибка получения данных');
        return throwError(err);
      })
    );
  }
}
