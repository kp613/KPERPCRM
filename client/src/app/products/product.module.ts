import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductListComponent } from './product-list/product-list.component';
import { SharedModule } from '../shared.module';
import { RouterModule } from '@angular/router';
import { ProductCardComponent } from './product-card/product-card.component';
import { MemberModule } from '../members/member.module';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ProductRoutingModule } from './product-routing.module';
import { ProductEditComponent } from './product-edit/product-edit.component';
import { ProductItemComponent } from './product-item/product-item.component';
import { SweetAlert2Module } from "@sweetalert2/ngx-sweetalert2";
import { ProductAddComponent } from './product-add/product-add.component';


@NgModule({
  declarations: [
    ProductListComponent,
    ProductDetailComponent,
    ProductCardComponent,
    ProductEditComponent,
    ProductItemComponent,
    ProductAddComponent
  ],
  imports: [
    MemberModule,
    SharedModule,
    ProductRoutingModule,

    SweetAlert2Module.forRoot(),
  ],
  exports: [
  ]
})
export class ProductModule { }
