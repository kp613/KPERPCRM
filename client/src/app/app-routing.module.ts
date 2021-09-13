import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminRoleComponent } from './admin/admin-role/admin-role.component';
import { DashboardComponent } from './admin/dashboard/dashboard.component';
import { HomeComponent } from './admin/home/home.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MessageComponent } from './admin/message/message.component';
import { UserComponent } from './members/user/user.component';
import { OrderListComponent } from './business/order-list/order-list.component';
import { CustomerDetailComponent } from './customers/customer-detail/customer-detail.component';
import { CustomerListComponent } from './customers/customer-list/customer-list.component';
import { ProductDetailComponent } from './products/product-detail/product-detail.component';
import { ProductFormComponent } from './products/product-form/product-form.component';
import { ProductListComponent } from './products/product-list/product-list.component';
import { AdminGuard } from './_guards/admin.guard';
import { AuthGuard } from './_guards/auth.guard';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { PreventUnsavedChangesGuard } from './_guards/prevent-unsaved-changes.guard';
import { ProductEditComponent } from './products/product-edit/product-edit.component';
import { MemberDetailedResolver } from './_resolvers/member-detailed.resolver';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: "admin", component: AdminRoleComponent, canActivate: [AdminGuard] },
      { path: "members/:username", component: MemberDetailComponent, resolve: { member: MemberDetailedResolver } },
      { path: "member/edit", component: MemberEditComponent, canDeactivate: [PreventUnsavedChangesGuard] },
      { path: "product/edit", component: ProductEditComponent, canDeactivate: [PreventUnsavedChangesGuard] },
      { path: "products", component: ProductListComponent },
      { path: 'messages', component: MessageComponent },
    ]
  },
  { path: "dashboard", component: DashboardComponent, canActivate: [AuthGuard] },
  // { path: "messages", component: MessageComponent },
  { path: "members", component: MemberListComponent },
  { path: "users", component: UserComponent },
  { path: "roles", component: AdminRoleComponent },
  { path: "orders", component: OrderListComponent },

  { path: "product/new", component: ProductFormComponent },
  { path: "products/:id", component: ProductDetailComponent },
  { path: "customers", component: CustomerListComponent },
  { path: "customers/:id", component: CustomerDetailComponent },

  { path: '**', component: HomeComponent, pathMatch: 'full' }
  // { path: "", redirectTo: "", pathMatch: "full" },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
