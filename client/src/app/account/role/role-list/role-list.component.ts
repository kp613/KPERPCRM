import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { IRole } from '../role';
import { AdminService } from '../role.service';

@Component({
  selector: 'app-role-list',
  templateUrl: './role-list.component.html',
  styleUrls: ['./role-list.component.scss']
})
export class RoleListComponent implements OnInit {
  model: any = {};
  @ViewChild('addRoleForm') addRoleForm: NgForm;
  roles: IRole[] = [];

  constructor(private adminService: AdminService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.loadRoles();
  }

  addRole() {
    this.adminService.addRoles(this.addRoleForm.value).subscribe(role => {
      this.addRoleForm.reset();
      this.toastr.success('增加角色成功！');
      this.loadRoles();
    }, error => {
      this.toastr.error(error.error);
    });
  }

  editRole() {

  }

  deleteRole(roles) {
    this.adminService.deleteRole(roles).subscribe(res => {
      this.toastr.success('角色已删除');
      this.loadRoles();
    }, error => {
      this.toastr.error(error.error);
    });
  }

  loadRoles() {
    this.adminService.getRoles().subscribe(response => {
      this.roles = response;
    })
  }

  cancel() {
    this.addRoleForm.reset();
  }
}
