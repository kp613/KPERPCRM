import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PreventUnsavedChangesGuard } from '../_guards/prevent-unsaved-changes.guard';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ProductEditComponent } from './product-edit/product-edit.component';
import { ProductListComponent } from './product-list/product-list.component';

const routes: Routes = [
  { path: "products/:casno", component: ProductDetailComponent },
  { path: "products/edit/:casno", component: ProductEditComponent, canDeactivate: [PreventUnsavedChangesGuard] },
  { path: "products", component: ProductListComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductRoutingModule { }
