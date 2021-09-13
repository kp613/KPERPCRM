import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductFormComponent } from './product-form/product-form.component';
import { ProductListComponent } from './product-list/product-list.component';
import { SharedModule } from '../shared.module';
import { RouterModule } from '@angular/router';
import { ProductCardComponent } from './product-card/product-card.component';
import { MemberModule } from '../members/member.module';
import { ProductDetailComponent } from './product-detail/product-detail.component';



@NgModule({
  declarations: [
    ProductFormComponent,
    ProductListComponent,
    ProductDetailComponent,
    ProductCardComponent,

  ],
  imports: [
    RouterModule,
    CommonModule,
    MemberModule,
    SharedModule,
  ],
  exports: [
  ]
})
export class ProductModule { }
