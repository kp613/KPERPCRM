import { NgModule } from '@angular/core';
import { ProductListComponent } from './product-list/product-list.component';
import { SharedModule } from '../shared.module';
import { ProductCardComponent } from './product-card/product-card.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ProductEditComponent } from './product-edit/product-edit.component';
import { ProductItemComponent } from './product-item/product-item.component';
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
    SharedModule,
   ],
  exports: [
  ]
})
export class ProductModule { }
