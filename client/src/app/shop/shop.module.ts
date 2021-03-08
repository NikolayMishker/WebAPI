import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ProductItemModule } from '../product-item/productItem.module';
import { SharedModule } from '../shared/shared.module';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [ShopComponent, ProductDetailsComponent],
  imports: [
    CommonModule,
    ProductItemModule,
    SharedModule,
    RouterModule
  ],
  exports: [ShopComponent]
})
export class ShopModule { }
