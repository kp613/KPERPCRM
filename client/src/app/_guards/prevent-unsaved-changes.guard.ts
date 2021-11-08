import { Injectable } from '@angular/core';
import { CanDeactivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { RegisterEditComponent } from '../account/register/register-edit/register-edit.component';
import { ProductEditComponent } from '../products/product-edit/product-edit.component';

@Injectable({
  providedIn: 'root'
})
export class PreventUnsavedChangesGuard implements CanDeactivate<unknown> {
  canDeactivate(registerEditComponent: RegisterEditComponent): boolean {
    if (registerEditComponent.editForm.dirty) {
      return confirm('是否要离开现在的编辑页面？未保存的内容将丢失');
    }
    return true;
  }

}
