import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { ProductService } from 'src/app/services/product/product.service';
import { Item } from 'src/app/types/Item';
import { Product } from 'src/app/types/product';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss'],
})
export class SearchComponent {
  searchQuery: string = '';
  searchResults: Product[] = [];

  private productService: ProductService = inject(ProductService);
  private router = inject(Router);
  constructor() {}

  search() {
    if (this.searchQuery) {
      this.productService
        .searchByBrand(this.searchQuery)
        .subscribe((results) => {
          this.searchResults = results;
        });
    } else {
      this.searchResults = [];
    }
  }

  clearSearch() {
    this.searchQuery = '';
    this.searchResults = [];
  }

  navigateToProductDetails(productId: number) {
    this.router.navigate(['/brands/model/', productId]);
    this.clearSearch();
  }
}
