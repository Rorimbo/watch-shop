import { Component } from '@angular/core';
import { ProductService } from 'src/app/services/product/product.service';
import { Products } from 'src/app/types/Products';
import { ProductsWithBrands } from 'src/app/types/ProductsWithBrands';

@Component({
  selector: 'app-brands',
  templateUrl: './brands.component.html',
  styleUrls: ['./brands.component.css'],
})
export class BrandsComponent {
  // products: Products[];
  productsWithBrands: ProductsWithBrands[] = [];

  constructor(public productService: ProductService) {}

  ngOnInit() {
    this.productService.getAllProducts().subscribe((productsWithBrands) => {
      this.productsWithBrands = productsWithBrands;
    });
  }
}
