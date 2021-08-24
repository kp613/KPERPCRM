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

@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    BsDropdownModule.forRoot(),
    DataTablesModule,
    Ng2SmartTableModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
    MatSliderModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    TabsModule.forRoot(),
  ],
  exports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    BsDropdownModule,
    DataTablesModule,
    Ng2SmartTableModule,
    ToastrModule,
    MatSliderModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    TabsModule,
  ]
})
export class SharedModule { }
