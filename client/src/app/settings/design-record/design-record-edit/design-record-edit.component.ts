import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { IDesignRecord } from '../design-recore';
import { Location } from '@angular/common';
import { DesignRecordService } from '../design-record.service';

@Component({
  selector: 'app-design-record-edit',
  templateUrl: './design-record-edit.component.html',
  styleUrls: ['./design-record-edit.component.scss']
})
export class DesignRecordEditComponent implements OnInit {
  id: number;
  designRecord: IDesignRecord;
  editGroupForm: FormGroup;
  crudRecords = [
    'List',
    'Created',
    'Read',
    'Updated',
    'Deleted',
    'Other'];

  folderNames = [
    'settings',
    'admin',
    'business',
    'products',
    'customers',
    'members',
    'modals',
    'account',
    'weblayout'
  ];

  constructor(
    private designRecordService: DesignRecordService,
    private httpClient: HttpClient,
    private fb: FormBuilder,
    private toastr: ToastrService,
    private router: Router,
    private route: ActivatedRoute,
    private location: Location,
  ) { }

  ngOnInit(): void {
    this.editForm();
  }

  editForm() {
    this.editGroupForm = this.fb.group({
      id: [''],
      folderName: ['', [Validators.required]],
      componentName: ['', [Validators.required]],
      progressAndProblem: [''],
      crudState: ['', [Validators.required]]
    });

    this.id = this.route.snapshot.params['id'];
    this.designRecordService.getRecordById(this.id).subscribe(response => {
      this.editGroupForm.patchValue(response);
    });
  }

  onSubmit(formData) {
    this.designRecordService.update(this.id, formData.value).subscribe((res) => {
      this.router.navigateByUrl('/webdesign');
      this.toastr.success('修改网站设计条目成功');
    }, (error) => {
      this.toastr.error(error.error);
    })
  }

  goBack(): void {
    this.location.back();
  }
}