import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CheckputComponent } from './checkput.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path: '', component: CheckputComponent}
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class CheckoutRoutingModule { }
