import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './admin/dashboard/dashboard.component';
import { HomeComponent } from './admin/home/home.component';
import { MemberDetailComponent } from './account/members/member-detail/member-detail.component';
import { MessageComponent } from './admin/message/message/message.component';
import { OrderListComponent } from './business/order-list/order-list.component';
import { CustomerDetailComponent } from './customers/customer-detail/customer-detail.component';
import { CustomerListComponent } from './customers/customer-list/customer-list.component';
import { AdminGuard } from './_guards/admin.guard';
import { AuthGuard } from './_guards/auth.guard';
import { MemberListComponent } from './account/members/member-list/member-list.component';
import { MemberDetailedResolver } from './_resolvers/member-detailed.resolver';
import { ProductRoutingModule } from './products/product-routing.module';
import { SettingRoutingModule } from './settings/setting-routing.module';
import { AccountRoutingModule } from './account/account-routing.module';
import { RoleListComponent } from './account/role/role-list/role-list.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: "admin", component: RoleListComponent, canActivate: [AdminGuard] },
      { path: "members/:username", component: MemberDetailComponent, resolve: { member: MemberDetailedResolver } },


      { path: 'messages', component: MessageComponent },
    ]
  },
  { path: "dashboard", component: DashboardComponent, canActivate: [AuthGuard] },
  // { path: "messages", component: MessageComponent },
  { path: "members", component: MemberListComponent },

  { path: "orders", component: OrderListComponent },

  { path: "customers", component: CustomerListComponent },
  { path: "customers/:id", component: CustomerDetailComponent },

  { path: 'account', loadChildren: () => import('./account/account.module').then(mod => mod.AccountModule), data: { breadcrumb: { skip: true } } },

  { path: '**', component: HomeComponent, pathMatch: 'full' },
  // { path: "", redirectTo: "", pathMatch: "full" },
  
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes),
    AccountRoutingModule,
    ProductRoutingModule,
    SettingRoutingModule
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
