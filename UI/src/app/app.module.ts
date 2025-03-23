import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { MatRadioModule } from '@angular/material/radio';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSnackBarModule } from '@angular/material/snack-bar';

import { SwiperModule } from 'swiper/angular';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { HomeComponent } from './pages/home/home.component';
import { BrandsComponent } from './pages/brands/brands.component';
import { NewsComponent } from './pages/news/news.component';
import { AboutComponent } from './pages/about/about.component';
import { ModelComponent } from './pages/model/model.component';
import { CartComponent } from './pages/cart/cart.component';
import { OrderComponent } from './pages/order/order.component';

import { HeaderComponent } from './components/header/header.component';
import { DialogComponent } from './components/dialog/dialog.component';
import { AgreementDialogComponent } from './components/agreement-dialog/agreement-dialog.component';
import { SearchComponent } from './components/search/search.component';
import { ProductComponent } from './components/product/product.component';

import {
  OrderApiService,
  OrderService,
  ProductApiService,
  ProductService,
} from './services';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    AppRoutingModule,
    ReactiveFormsModule,
    BrowserModule,
    BrowserAnimationsModule,
    MatRadioModule,
    MatInputModule,
    MatIconModule,
    MatMenuModule,
    MatButtonModule,
    MatCheckboxModule,
    MatDialogModule,
    HttpClientModule,
    MatSnackBarModule,
    SwiperModule,
  ],
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
    BrandsComponent,
    NewsComponent,
    AboutComponent,
    ModelComponent,
    CartComponent,
    OrderComponent,
    DialogComponent,
    AgreementDialogComponent,
    SearchComponent,
    ProductComponent,
  ],

  providers: [OrderService, OrderApiService, ProductService, ProductApiService],
  bootstrap: [AppComponent],
})
export class AppModule {}
