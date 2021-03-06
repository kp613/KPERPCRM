import { NgModule } from '@angular/core';
import { ProductListComponent } from './product/product-list/product-list.component';
import { SharedModule } from '../shared.module';
import { ProductCardComponent } from './product/product-card/product-card.component';
import { ProductDetailComponent } from './product/product-detail/product-detail.component';
import { ProductEditComponent } from './product/product-edit/product-edit.component';
import { ProductItemComponent } from './product/product-item/product-item.component';
import { ProductAddComponent } from './product/product-add/product-add.component';
import { CategoryFirstComponent } from './category/category-first/category-first.component';
import { CategorySecondComponent } from './category/category-second/category-second.component';
import { CategoryThirdComponent } from './category/category-third/category-third.component';
import { SettingModule } from '../settings/setting.module';
import { GeneralModule } from '../_core/general.module';
import { CategoryComponent } from './category/category.component';
import { CategorySecondAddComponent } from './category/category-second/category-second-add/category-second-add.component';
import { CategorySecondEditComponent } from './category/category-second/category-second-edit/category-second-edit.component';


@NgModule({
  declarations: [
    ProductListComponent,
    ProductDetailComponent,
    ProductCardComponent,
    ProductEditComponent,
    ProductItemComponent,
    ProductAddComponent,
    CategoryFirstComponent,
    CategorySecondComponent,
    CategoryThirdComponent,
    CategoryComponent,
    CategorySecondAddComponent,
    CategorySecondEditComponent,

  ],
  imports: [
    SharedModule,

    SettingModule,
    GeneralModule
  ],
  exports: [
  ]
})
export class ProductModule { }
