import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ProductItemModule } from '../product-item/productItem.module';
import { SharedModule } from '../shared/shared.module';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ShopRoutingModule } from './shop-routing.module';



@NgModule({
  declarations: [ShopComponent, ProductDetailsComponent],
  imports: [
    CommonModule,
    ProductItemModule,
    SharedModule,
    ShopRoutingModule
  ]
})
export class ShopModule { }
