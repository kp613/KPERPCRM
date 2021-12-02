import { NgModule } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { CustomerModule } from './customers/customer.module';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { LoadingInterceptor } from './_core/interceptors/loading.interceptor';
import { NgxSpinnerModule } from 'ngx-spinner';
import { ProductModule } from './products/product.module';
import { WeblayoutModule } from './weblayout/weblayout.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { DataTablesModule } from 'angular-datatables';
import { AdminModule } from './admin/admin.module';
import { JwtInterceptor } from './_core/interceptors/jwt.interceptor';
import { GeneralModule } from './_core/shared/general.module';
import { SharedModule } from './shared.module';
import { SettingModule } from './settings/setting.module';
import { AccountModule } from './account/account.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    SharedModule,
    HttpClientModule,
    FontAwesomeModule,
    NgxSpinnerModule,
    DataTablesModule,

    AppRoutingModule,
    AccountModule,
    GeneralModule,
    AdminModule,
    ProductModule,
    CustomerModule,
    WeblayoutModule,
    SettingModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true },
    Title
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
