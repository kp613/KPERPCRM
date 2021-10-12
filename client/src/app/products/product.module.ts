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



@NgModule({
  declarations: [
    ProductListComponent,
    ProductDetailComponent,
    ProductCardComponent,
    ProductEditComponent,
    ProductItemComponent
  ],
  imports: [
    MemberModule,
    SharedModule,
    ProductRoutingModule
  ],
  exports: [
  ]
})
export class ProductModule { }
