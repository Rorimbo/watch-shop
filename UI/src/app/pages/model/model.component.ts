import { Component, ViewEncapsulation } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { DialogComponent } from 'src/app/components/dialog/dialog.component';
import { ITEMS } from 'src/app/Mocks/Items';
import { CartItem } from 'src/app/types/cart-item';
import { Item } from 'src/app/types/Item';
import { ProductService } from 'src/app/services/product/product.service';
import { Product } from 'src/app/types/product';

@Component({
  selector: 'app-model',
  templateUrl: './model.component.html',
  styleUrls: ['./model.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class ModelComponent {
  id: number;
  items: Item[];
  currentItem?: Item;
  cartItems: CartItem[];
  total: number = 0;
  products: Product[];

  constructor(
    public productService: ProductService,
    public route: ActivatedRoute,
    public dialog: MatDialog
  ) {
    route.params.subscribe((params) => (this.id = params['id']));
    this.currentItem = this.items.find((item) => item.id == this.id);
  }

  // ngOnInit() {
  //   this.productService.getProductId(item).subscribe(() => {
  //     this.id = product.id;
  //   });
  // }

  // submitForm() {
  //   if (this.cartItems.find((el) => el.id == this.id)) {
  //     this.cartItems = this.cartItems.map((el) => {
  //       if (el.id == this.id) {
  //         el.price = el.price * el.quantity;
  //         el.totalAmount += el.price;
  //       }
  //       return el;
  //     });
  //   } else {
  //     if (this.currentItem) {
  //       let newCartItem: CartItem = {
  //         id: this.currentItem.id,
  //         brandId: this.currentItem.brandId,
  //         model: this.currentItem.model,
  //         price: this.currentItem.price,
  //         brandName: this.currentItem.brandName,
  //         brandCountry: this.currentItem.brandCountry,
  //         totalAmount: this.currentItem.price,
  //         quantity: 1,
  //       };
  //       this.cartItems.unshift(newCartItem);
  //     }
  //   }

  //   this.openDialog();
  // }

  addToCart(productId: number) {
    this.productService.updateCart(productId, 1).subscribe();
  }

  openDialog() {
    this.dialog.open(DialogComponent, {
      data: { dialogText: 'Товар добавлен в корзину' },
    });
  }
}
