import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CheckputComponent } from './checkput.component';
import { CheckoutRoutingModule } from './checkout-routing.module';

@NgModule({
  declarations: [CheckputComponent],
  imports: [
    CommonModule,
    CheckoutRoutingModule
  ]
})
export class CheckoutModule { }
