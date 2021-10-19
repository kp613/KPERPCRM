import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { DataTablesModule } from 'angular-datatables';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';
import { AuthGuard } from './_guards/auth.guard';
import { HomeComponent } from './admin/home/home.component';
import { MatSliderModule } from '@angular/material/slider';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { TimeagoModule } from 'ngx-timeago';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { CdkStepperModule } from '@angular/cdk/stepper';
import { MaterialModule } from './_shared/material.module';
import { NgxPaginationModule } from 'ngx-pagination';

@NgModule({
  declarations: [
  ],
  imports: [
    RouterModule,
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    BsDropdownModule.forRoot(),
    DataTablesModule,
    Ng2SmartTableModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
    TabsModule.forRoot(),
    BsDatepickerModule.forRoot(),
    PaginationModule.forRoot(),
    TimeagoModule.forRoot(),
    ButtonsModule.forRoot(),
    CdkStepperModule,
    MaterialModule,
    NgxPaginationModule
  ],
  exports: [
    RouterModule,
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    BsDropdownModule,
    DataTablesModule,
    Ng2SmartTableModule,
    ToastrModule,
    TabsModule,
    BsDatepickerModule,
    PaginationModule,
    TimeagoModule,
    ButtonsModule,
    CdkStepperModule,
    MaterialModule,
    NgxPaginationModule
  ]
})
export class SharedModule { }
