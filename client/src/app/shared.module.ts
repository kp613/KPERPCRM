import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { DataTablesModule } from 'angular-datatables';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { TimeagoModule } from 'ngx-timeago';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { CdkStepperModule } from '@angular/cdk/stepper';
import { MaterialModule } from './_core/shared/material.module';
import { NgxPaginationModule } from 'ngx-pagination';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { HttpClientModule } from '@angular/common/http';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgxSpinnerModule } from 'ngx-spinner';
import { AngularFileUploaderModule } from "angular-file-uploader";

@NgModule({
  declarations: [
  ],
  imports: [
    HttpClientModule,
    FontAwesomeModule,
    NgxSpinnerModule,
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
    NgxPaginationModule,
    SweetAlert2Module.forRoot(),
    AngularFileUploaderModule,


  ],
  exports: [
    HttpClientModule,
    FontAwesomeModule,
    NgxSpinnerModule,
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
    NgxPaginationModule,
    SweetAlert2Module,
    AngularFileUploaderModule,


  ]
})
export class SharedModule { }
