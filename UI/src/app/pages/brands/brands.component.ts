import { Component, Input } from '@angular/core';
import { map } from 'rxjs';
import { ProductService } from 'src/app/services/product/product.service';

@Component({
  selector: 'app-brands',
  templateUrl: './brands.component.html',
  styleUrls: ['./brands.component.css'],
})
export class BrandsComponent {
  @Input() limit: number;

  products$ = this.productService.getAllProducts().pipe(
    map((products) => {
      if (this.limit) {
        return products.slice(0, this.limit);
      }
      return products;
    })
  );

  constructor(public productService: ProductService) {}

  ngOnInit() {}

  addToCart(productId: number) {
    this.productService.updateCart(productId, 1).subscribe();
  }
}
