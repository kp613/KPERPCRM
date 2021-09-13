import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { IRole } from 'src/app/_models/role';
import { AdminService } from 'src/app/admin/admin-role/role.service';

@Component({
  selector: 'app-admin-role',
  templateUrl: './admin-role.component.html',
  styleUrls: ['./admin-role.component.scss']
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
