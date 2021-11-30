import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategpryHomeComponent } from './category/categpry-home/categpry-home.component';
import { ProductDetailComponent } from './product/product-detail/product-detail.component';
import { ProductEditComponent } from './product/product-edit/product-edit.component';
import { ProductListComponent } from './product/product-list/product-list.component';

const routes: Routes = [
  { path: "products/:casno", component: ProductDetailComponent },
  { path: "products/edit/:id", component: ProductEditComponent },
  // { path: "products/edit/:id", component: ProductEditComponent, canDeactivate: [PreventUnsavedChangesGuard] },
  { path: "products", component: ProductListComponent },
  { path: "product-category", component: CategpryHomeComponent },
  { path: "product-category/:firstId", component: CategpryHomeComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductRoutingModule { }
