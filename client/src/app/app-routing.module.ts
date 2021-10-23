import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminRoleComponent } from './account/role/role.component';
import { DashboardComponent } from './admin/dashboard/dashboard.component';
import { HomeComponent } from './admin/home/home.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MessageComponent } from './admin/message/message/message.component';
import { UserComponent } from './members/user/user.component';
import { OrderListComponent } from './business/order-list/order-list.component';
import { CustomerDetailComponent } from './customers/customer-detail/customer-detail.component';
import { CustomerListComponent } from './customers/customer-list/customer-list.component';
import { AdminGuard } from './_guards/admin.guard';
import { AuthGuard } from './_guards/auth.guard';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { PreventUnsavedChangesGuard } from './_guards/prevent-unsaved-changes.guard';
import { MemberDetailedResolver } from './_resolvers/member-detailed.resolver';
import { ProductRoutingModule } from './products/product-routing.module';
import { ProductDetailComponent } from './products/product-detail/product-detail.component';
import { SettingRoutingModule } from './settings/setting-routing.module';

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

      { path: 'messages', component: MessageComponent },
    ]
  },
  { path: "dashboard", component: DashboardComponent, canActivate: [AuthGuard] },
  // { path: "messages", component: MessageComponent },
  { path: "members", component: MemberListComponent },
  { path: "users", component: UserComponent },
  { path: "roles", component: AdminRoleComponent },
  { path: "orders", component: OrderListComponent },

  { path: "customers", component: CustomerListComponent },
  { path: "customers/:id", component: CustomerDetailComponent },

  { path: 'account', loadChildren: () => import('./account/account.module').then(mod => mod.AccountModule), data: { breadcrumb: { skip: true } } },

  { path: '**', component: HomeComponent, pathMatch: 'full' }
  // { path: "", redirectTo: "", pathMatch: "full" },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes),
    ProductRoutingModule,
    SettingRoutingModule
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
