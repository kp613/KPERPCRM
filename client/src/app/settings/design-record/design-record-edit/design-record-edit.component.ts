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

  crudRecords = [];
  folderNames = [];

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
      progressAndProblem: ['', [Validators.required]],
      crudState: ['', [Validators.required]]
    });


    this.crudRecords = this.designRecordService.crudRecords;
    this.folderNames = this.designRecordService.folderNames;

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
