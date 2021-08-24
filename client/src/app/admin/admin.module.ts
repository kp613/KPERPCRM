import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoginComponent } from './login/login.component';
import { AdminRoleComponent } from './admin-role/admin-role.component';
import { HomeComponent } from './home/home.component';
import { MessageComponent } from './message/message.component';
import { SharedModule } from '../shared.module';
import { RegisterComponent } from './register/register.component';
import { RouterModule } from '@angular/router';
import { UserComponent } from './user/user.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';

@NgModule({
  declarations: [
    LoginComponent,
    AdminRoleComponent,
    HomeComponent,
    MessageComponent,
    RegisterComponent,
    UserComponent,
    DashboardComponent,
  ],
  imports: [
    RouterModule,
    CommonModule,
    SharedModule,
  ],
  exports: [
    AdminRoleComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent
  ]
})
export class AdminModule { }
