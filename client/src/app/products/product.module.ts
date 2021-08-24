import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductFormComponent } from './product-form/product-form.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ProductListComponent } from './product-list/product-list.component';
import { SharedModule } from '../shared.module';
import { AdminModule } from '../admin/admin.module';
import { RouterModule } from '@angular/router';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { ProductCardComponent } from './product-card/product-card.component';
import { ProductEditComponent } from './product-edit/product-edit.component';



@NgModule({
  declarations: [
    ProductFormComponent,
    ProductListComponent,
    ProductDetailComponent,
    ProductCardComponent,
    ProductEditComponent,

  ],
  imports: [
    RouterModule,
    CommonModule,
    AdminModule,
    SharedModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
  ],
  exports: [
    ProductFormComponent,
    ProductListComponent,
    ProductDetailComponent,
  ]
})
export class ProductModule { }
