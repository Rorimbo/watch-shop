import { Component, Input } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { AgreementDialogComponent } from '../../components/agreement-dialog/agreement-dialog.component';
import { OrderDetails } from 'src/app/types/order-details';
import { OrderService } from 'src/app/services';
import { CartItem } from 'src/app/types/cart-item';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css'],
})
export class OrderComponent {
  @Input() cart: CartItem[];
  @Input() totalAmount: number;

  orderForm: FormGroup;
  isSelectPickup: boolean;
  isSelectDelivery: boolean;

  constructor(public orderService: OrderService, public dialog: MatDialog) {
    this.orderForm = new FormGroup({
      name: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.email]),
      phone: new FormControl('', [
        Validators.required,
        Validators.pattern('[0-9]{10}'),
      ]),
      country: new FormControl('', [Validators.required]),
      city: new FormControl('', [Validators.required]),

      delivery: new FormControl('', [Validators.required]),

      address: new FormControl('', [Validators.required]),
      index: new FormControl('', [
        Validators.required,
        Validators.pattern('[0-9]{6}'),
      ]),
      comment: new FormControl(''),

      pay: new FormControl('', [Validators.required]),

      agreement: new FormControl('', [Validators.requiredTrue]),
      notification: new FormControl('', []),
    });
  }

  selectPichup() {
    this.isSelectPickup = true;
    this.isSelectDelivery = false;
  }

  selectDelivery() {
    this.isSelectDelivery = true;
    this.isSelectPickup = false;
  }

  createOrder() {
    console.log(this.orderForm.value);
    let orderDetails: OrderDetails = {
      cart: this.cart,
      userId: 1,
      totalAmount: this.totalAmount,
      shippingAddress: this.orderForm.value.address,
      paymentMethod: this.orderForm.value.pay,
    };

    this.orderService.createOrder(orderDetails).subscribe(() => {
      // this.orderForm = orderDetails;
    });
  }

  getFormControl(formControlName: string) {
    return this.orderForm.get(formControlName);
  }

  agreementDialog() {
    const dialogRef = this.dialog.open(AgreementDialogComponent);

    dialogRef.afterClosed().subscribe((result) => {
      console.log(`Dialog result: ${result}`);
    });
  }
}
