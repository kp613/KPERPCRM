import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './navbar/navbar.component';
import { MainComponent } from './main/main.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared.module';



@NgModule({
  declarations: [
    NavbarComponent,
    SidebarComponent,
    MainComponent,
  ],
  imports: [
    SharedModule
  ],
  exports: [
    NavbarComponent,
    SidebarComponent,
    MainComponent
  ]
})
export class WeblayoutModule { }
