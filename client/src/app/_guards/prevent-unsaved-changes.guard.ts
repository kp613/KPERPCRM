import { Injectable } from '@angular/core';
import { CanDeactivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { MemberEditComponent } from '../account/members/member-edit/member-edit.component';
import { ProductEditComponent } from '../products/product-edit/product-edit.component';

@Injectable({
  providedIn: 'root'
})
export class PreventUnsavedChangesGuard implements CanDeactivate<unknown> {
  canDeactivate(memberEditComponent: MemberEditComponent): boolean {
    if (memberEditComponent.editForm.dirty) {
      return confirm('是否要离开现在的编辑页面？未保存的内容将丢失');
    }
    return true;
  }

}
