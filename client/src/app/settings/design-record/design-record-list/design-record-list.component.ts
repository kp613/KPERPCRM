import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DesignRecordService } from '../design-record.service';
import { IDesignRecord } from '../design-recore';

@Component({
  selector: 'app-design-record-list',
  templateUrl: './design-record-list.component.html',
  styleUrls: ['./design-record-list.component.scss']
})
export class DesignRecordListComponent implements OnInit {
  id: number;
  isFinished: boolean = false;
  formData;

  designRecords: IDesignRecord[];

  constructor(
    private designRecordService: DesignRecordService,
    private toastr: ToastrService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.loadDesignRecordLists();
  }

  loadDesignRecordLists() {
    // this.designRecords$ = this.designRecordService.getLists();
    this.designRecordService.getLists().subscribe(records => {
      this.designRecords = records;
    }, error => {
      console.log(error);
    })
  }

  getFinished() {
    this.designRecordService.update(this.id, this.formData.value).subscribe((res) => {
      this.router.navigateByUrl('/webdesign');
      this.toastr.success('修改finished成功');
    }, (error) => {
      this.toastr.error(error.error);
    })
  }

}
