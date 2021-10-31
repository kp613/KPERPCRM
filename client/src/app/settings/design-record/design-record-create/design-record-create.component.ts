import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DesignRecordService } from '../design-record.service';
import { IDesignRecord } from '../design-recore';
import { Location } from '@angular/common';

@Component({
  selector: 'app-design-record-create',
  templateUrl: './design-record-create.component.html',
  styleUrls: ['./design-record-create.component.scss']
})
export class DesignRecordCreateComponent implements OnInit {
  designRecord: IDesignRecord;
  addGroupForm: FormGroup;
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
    private httpClient: HttpClient,
    private fb: FormBuilder,
    private toastr: ToastrService,
    private router: Router,
    private location: Location,
    private designRecordService: DesignRecordService
  ) { }

  ngOnInit(): void {
    this.createForm();
  }


  createForm() {
    this.addGroupForm = this.fb.group({
      folderName: ['', [Validators.required]],
      componentName: ['', [Validators.required]],
      progressAndProblem: [''],
      crudState: ['']
    })
  }

  onSaveForm() {
    this.designRecordService.create(this.addGroupForm.value).subscribe((res) => {
      this.toastr.success('增加网站设计条目成功');
    }, (error) => {
      this.toastr.error(error.error);
    })
  }


  cancel() {
    this.addGroupForm.reset();
  }

  goBack(): void {
    this.location.back();
  }

}
