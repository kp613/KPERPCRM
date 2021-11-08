import { HttpClient } from '@angular/common/http';
import { Component, OnDestroy, OnInit } from '@angular/core';
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

  crudRecords = [];
  folderNames = [];

  editParam = {
    selector: 'textarea',  //tinymce的最基本的组件
    language_url: '../../../assets/tinymce-lang/zh_CN.js',
    language: 'zh_CN',
    height: 500
  };

  constructor(
    private httpClient: HttpClient,
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private router: Router,
    private location: Location,
    private designRecordService: DesignRecordService
  ) { }

  ngOnInit(): void {

    this.createForm();
  }


  createForm() {
    this.addGroupForm = this.formBuilder.group({
      folderName: ['', [Validators.required]],
      componentName: ['', [Validators.required]],
      progressAndProblem: [''],
      crudState: ['', [Validators.required]]
    });

    this.crudRecords = this.designRecordService.crudRecords;
    this.folderNames = this.designRecordService.folderNames;
  }

  onSaveForm() {
    this.designRecordService.create(this.addGroupForm.value).subscribe((res) => {
      this.router.navigateByUrl('/webdesign');
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


