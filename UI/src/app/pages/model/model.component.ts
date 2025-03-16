import { Component, ViewEncapsulation } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { DialogComponent } from 'src/app/components/dialog/dialog.component';
import { ITEMS } from 'src/app/mocks/Items';
import { OrderService } from 'src/app/services/order/order.service';
import { CartItem } from 'src/app/types/CartItem';
import { Item } from 'src/app/types/Item';
import { Cart } from 'src/app/types/Сart';

@Component({
  selector: 'app-model',
  templateUrl: './model.component.html',
  styleUrls: ['./model.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class ModelComponent {
  id: number;
  items: Item[] = ITEMS;
  currentItem?: Item;
  cartItems: CartItem[];
  total: number = 0;
  cart: Cart;

  orderForm: FormGroup;

  constructor(
    public orderService: OrderService,
    private route: ActivatedRoute,
    public dialog: MatDialog
  ) {
    this.orderForm = new FormGroup({
      colorDial: new FormControl('', [Validators.required]),
    });

    route.params.subscribe((params) => (this.id = params['id']));
    this.currentItem = this.items.find((item) => item.id == this.id);
  }

  submitForm() {
    // if (
    //   this.cartItems.find(
    //     (el) =>
    //       el.id == this.id &&
    //       el.colorDial == this.orderForm.get('colorDial')?.value
    //   )
    // ) {
    //   this.cartItems = this.cartItems.map((el) => {
    //     if (
    //       el.id == this.id &&
    //       el.colorDial == this.orderForm.get('colorDial')?.value
    //     ) {
    //       el.amount = el.amount + 1;
    //       el.totalPrice = el.amount * el.price;
    //     }
    //     return el;
    //   });
    // } else {
    //   if (this.currentItem) {
    //     let newCartItem: CartItem = {
    //       id: this.currentItem.id,
    //       name: this.currentItem.name,
    //       colorDial: this.orderForm.get('colorDial')?.value,
    //       price: this.currentItem.price,
    //       totalPrice: this.currentItem.price,
    //       previewUrl: this.currentItem.previewUrl,
    //       amount: 1,
    //     };
    //     this.cartItems.unshift(newCartItem);
    //   }
    // }

    this.openDialog();
  }

  // addCart(cart: Cart) {
  //   return this.orderService.addCart(cart).subscribe((cart) => {
  //     this.cart = cart;
  //   });
  // }

  openDialog() {
    this.dialog.open(DialogComponent, {
      data: { dialogText: 'Товар добавлен в корзину' },
    });
  }
}
