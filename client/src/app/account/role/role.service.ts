import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'jquery';
import { Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ILoggedUser } from '../loggedUser';
import { Product } from '../../products/product';
import { IRole } from '../role';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  baseUrl = environment.apiUrl;
  roles: IRole[] = [];

  constructor(private http: HttpClient) { }

  getUsersWithRoles() {
    return this.http.get<Partial<ILoggedUser[]>>(this.baseUrl + 'api/admin/users-with-roles');
  }

  updateUserRoles(username: string, roles: string[]) {
    return this.http.post(this.baseUrl + 'api/admin/edit-roles/' + username + '?roles=' + roles, {});
  }

  getRoles(): Observable<IRole[]> {
    if (this.roles.length > 0) return of(this.roles);
    return this.http.get<IRole[]>(this.baseUrl + "api/rolemanage/roles");
  }

  addRoles(model: any) {
    return this.http.post(this.baseUrl + 'api/rolemanage/addrole', model);
  }

  editRoles(Role: []) {
    return this.http.post(this.baseUrl + 'api/rolemanage/', {});
  }

  deleteRole(roleId: string) {
    return this.http.delete(this.baseUrl + 'api/rolemanage/' + roleId, {});
  }

}


