import { NgModule } from '@angular/core';

import { HomeComponent } from './home/home.component';
import { MessageComponent } from './message/message/message.component';
import { SharedModule } from '../shared.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { GeneralModule } from '../_core/general.module';
import { AccountModule } from '../account/account.module';

@NgModule({
  declarations: [
    HomeComponent,
    MessageComponent,
    DashboardComponent,
  ],
  imports: [
    SharedModule,
    GeneralModule,
    AccountModule
  ],
  exports: [

  ]
})
export class AdminModule { }
