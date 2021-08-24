import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { OrderListComponent } from './order-list/order-list.component';



@NgModule({
  declarations: [
    OrderListComponent
  ],
  imports: [
    RouterModule,
    CommonModule
  ],
  exports: [
    OrderListComponent
  ]
})
export class OrderModule { }
