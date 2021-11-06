import { Component, OnInit } from '@angular/core';
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

  designRecords: IDesignRecord[];

  constructor(
    private designRecordService: DesignRecordService,
    private toastr: ToastrService
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

  // getFinished(id, isFinished) {
  //   this.designRecordService.setFinished(this.id, this.isFinished).subscribe(res => {
  //     this.toastr.success('该条目状态设置成功');
  //   }, (error) => {
  //     this.toastr.error(error.error);
  //   })
  // }
}
