import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoleComponent } from './admin-role/admin-role.component';
import { HomeComponent } from './home/home.component';
import { MessageComponent } from './message/message.component';
import { SharedModule } from '../shared.module';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MemberModule } from '../members/member.module';

@NgModule({
  declarations: [
    AdminRoleComponent,
    HomeComponent,
    MessageComponent,
    DashboardComponent,
  ],
  imports: [
    MemberModule,

    RouterModule,
    CommonModule,
    SharedModule,
  ],
  exports: [
    AdminRoleComponent,
    HomeComponent,
  ]
})
export class AdminModule { }
