import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ProductItemModule } from '../product-item/productItem.module';



@NgModule({
  declarations: [ShopComponent],
  imports: [
    CommonModule,
    ProductItemModule
  ],
  exports: [ShopComponent]
})
export class ShopModule { }
