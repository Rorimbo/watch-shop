import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { DialogComponent } from '../dialog/dialog.component';
import { AgreementDialogComponent } from '../agreement-dialog/agreement-dialog.component';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css'],
})
export class OrderComponent {
  orderForm: FormGroup;
  isSelectPickup: boolean;
  isSelectDelivery: boolean;

  constructor(public dialog: MatDialog) {
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

  submitForm() {
    console.log(this.orderForm.value);
    this.openDialog();
  }

  getFormControl(formControlName: string) {
    return this.orderForm.get(formControlName);
  }

  openDialog() {
    this.dialog.open(DialogComponent, {
      data: { dialogText: 'Заказ оформлен' },
    });
  }

  agreementDialog() {
    const dialogRef = this.dialog.open(AgreementDialogComponent);

    dialogRef.afterClosed().subscribe((result) => {
      console.log(`Dialog result: ${result}`);
    });
  }
}
