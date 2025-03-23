import { Component, inject } from '@angular/core';
import { Observable, of, tap } from 'rxjs';
import { ProductService } from 'src/app/services/product/product.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {
  title = 'Welcome to TimeCraft';

  isDiscountEmpty = false;
  isReviewEmpty = false;

  private productService = inject(ProductService);

  constructor() {}

  discounts$: Observable<any[]> = of([]).pipe(
    tap((discounts) => {
      if (discounts.length === 0) {
        this.isDiscountEmpty = true;
      } else {
        this.isDiscountEmpty = false;
      }
    })
  );

  reviews$: Observable<any[]> = of([]).pipe(
    tap((reviews) => {
      if (reviews.length === 0) {
        this.isReviewEmpty = true;
      } else {
        this.isReviewEmpty = false;
      }
    })
  );
}
