import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { IRole } from 'src/app/account/role';
import { AdminService } from 'src/app/account/role/role.service';

@Component({
  selector: 'app-admin-role',
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.scss']
})
export class AdminRoleComponent implements OnInit {
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
