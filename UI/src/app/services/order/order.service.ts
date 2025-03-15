import { inject, Injectable } from '@angular/core';
import { OrderApiService } from './order-api.service';
import { CartItem } from 'src/app/types/CartItem';
import { catchError, Observable, throwError } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';

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

  getCart(userId: number): Observable<CartItem[]> {
    return this.orderApiService.getCart(userId).pipe(
      catchError((err) => {
        this.openSnackBar('Ошибка получения данных');
        return throwError(err);
      })
    );
  }
}
