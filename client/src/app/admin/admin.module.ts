import { NgModule } from '@angular/core';

import { AdminRoleComponent } from '../account/role/role.component';
import { HomeComponent } from './home/home.component';
import { MessageComponent } from './message/message/message.component';
import { SharedModule } from '../shared.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MemberModule } from '../members/member.module';
import { GeneralModule } from '../_shared/general.module';

@NgModule({
  declarations: [
    AdminRoleComponent,
    HomeComponent,
    MessageComponent,
    DashboardComponent,
  ],
  imports: [
    MemberModule,
    SharedModule,
    GeneralModule
  ],
  exports: [

  ]
})
export class AdminModule { }
