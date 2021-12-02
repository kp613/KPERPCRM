import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PreventUnsavedChangesGuard } from '../_core/guards/prevent-unsaved-changes.guard';
import { LoginComponent } from './login/login.component';
import { RegisterEditComponent } from './register/register-edit/register-edit.component';
import { RegisterComponent } from './register/register/register.component';
import { RoleListComponent } from './role/role-list/role-list.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: "roles", component: RoleListComponent },

  { path: "register/edit", component: RegisterEditComponent, canDeactivate: [PreventUnsavedChangesGuard] },
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AccountRoutingModule { }
