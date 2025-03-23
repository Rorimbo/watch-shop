import { Component, inject, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from 'src/app/types/product';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
})
export class ProductComponent {
  @Input() product: Product;

  private router = inject(Router);

  navigateToModel() {
    this.router.navigate(['/brands/model', this.product.id]);
  }
}
