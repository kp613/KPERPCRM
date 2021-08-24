import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerDetailComponent } from './customer-detail/customer-detail.component';
import { CustomerListComponent } from './customer-list/customer-list.component';
import { SharedModule } from '../shared.module';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    CustomerListComponent,
    CustomerDetailComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    SharedModule
  ],
  exports: [
    CustomerListComponent,
    CustomerDetailComponent,
  ]
})
export class CustomerModule { }
