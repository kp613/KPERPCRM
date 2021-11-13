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
  isEdit: boolean = false;

  crudRecords = [];
  folderNames = [];

  editParam = {
    selector: 'textarea',  //tinymce的最基本的组件
    language_url: '../../../assets/tinymce-lang/zh_CN.js',
    language: 'zh_CN',
    // plugins: "autoresize",
    plugins: `autoresize link lists image code table colorpicker fullpage help
    textcolor wordcount  media preview print  hr directionality imagetools autosave paste`,
    toolbar: 'undo redo  removeformat paste  bold italic underline strikethrough  | fontsizeselect |  forecolor backcolor | bullist numlist h2 h3 h4| '
      + ' link unlink image  | alignleft aligncenter alignright outdent indent  |'
      + 'preview code help',
    // height: 500

    image_caption: true,
    // paset 插件允许粘贴图片
    paste_data_images: true,
    imagetools_toolbar: 'rotateleft rotateright | flipv fliph | editimage imageoptions',
    // 这个便是自定义上传图片方法
    images_upload_handler: function (blobInfo, success, failure) {
      let xhr, formData;
      xhr = new XMLHttpRequest();
      xhr.withCredentials = false;
      xhr.open('POST', '/api/upload');
      xhr.onload = function () {
        let json;
        if (xhr.status !== 200) {
          failure('HTTP Error: ' + xhr.status);
          return;
        }
        json = JSON.parse(xhr.responseText);
        if (!json || typeof json.location !== 'string') {
          failure('Invalid JSON: ' + xhr.responseText);
          return;
        }
        success(json.location);
      };
      formData = new FormData();
      formData.append('file', blobInfo.blob(), blobInfo.filename());
      xhr.send(formData);
    }
  };

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
      title: [''],
      progressAndProblem: [''],
      crudState: ['', [Validators.required]],
      finished: ['']
    });


    this.crudRecords = this.designRecordService.crudRecords;
    this.folderNames = this.designRecordService.folderNames;

    this.id = this.route.snapshot.params['id'];
    this.designRecordService.getRecordById(this.id).subscribe(response => {
      this.editGroupForm.patchValue(response);
    });

    this.isEdit = this.route.snapshot.params['isEdit'];
  }

  onSubmit(formData) {
    this.designRecordService.update(this.id, formData.value).subscribe((res) => {
      this.router.navigateByUrl('/webdesign');
      this.toastr.success('修改网站设计条目成功');
    }, (error) => {
      this.toastr.error(error.error);
    })
  }

  edit(): void {
    this.isEdit = true;
  }

  delete(id): void {
    this.designRecordService.delete(id).subscribe(res => {
      this.router.navigateByUrl('/webdesign');
      this.toastr.success('网站设计条目已成功删除');
    }, (error) => {
      this.toastr.error(error.error);
    })
  }

  goBack(): void {
    this.location.back();
  }
}
