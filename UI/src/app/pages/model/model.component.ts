import { Component, inject, ViewEncapsulation } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { CartItem } from 'src/app/types/cart-item';
import { Item } from 'src/app/types/Item';
import { ProductService } from 'src/app/services/product/product.service';
import { Product } from 'src/app/types/product';
import SwiperCore, { Pagination, Navigation, Autoplay } from 'swiper';

SwiperCore.use([Pagination, Navigation, Autoplay]);

@Component({
  selector: 'app-model',
  templateUrl: './model.component.html',
  styleUrls: ['./model.component.scss'],
  encapsulation: ViewEncapsulation.None,
})
export class ModelComponent {
  public route = inject(ActivatedRoute);
  id: number;
  currentItem?: Item;
  cartItems: CartItem[];
  totalAmount: number = 0;
  products: Product[];

  selectedImageId?: number | null;
  showTooltip: boolean = false;

  constructor(public productService: ProductService, public dialog: MatDialog) {
    this.route.params.subscribe((params) => {
      this.id = params['id'];
      this.productService.getInfoProduct(this.id).subscribe((currentItem) => {
        this.currentItem = currentItem;
      });
    });
  }

  addToCart(productId: number) {
    this.productService.updateCart(productId, 1).subscribe(() => {
      this.showTooltip = true;
      setTimeout(() => {
        this.showTooltip = false;
      }, 10000);
    });
  }

  openModal(index: number) {
    this.selectedImageId = index;
  }

  closeModal() {
    this.selectedImageId = null;
  }
}
