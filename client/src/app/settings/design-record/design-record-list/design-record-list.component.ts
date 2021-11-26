import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
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
  // finished: boolean = false;
  dtOptions: DataTables.Settings = {};

  finishedForm = new FormGroup({
    finished: new FormControl(''),
    id: new FormControl('')
  })

  designRecords: IDesignRecord[];
  designRecord: IDesignRecord;

  constructor(
    private designRecordService: DesignRecordService,
    private toastr: ToastrService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10,
      processing: true
    };

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

  // getFinished() {
  //   this.designRecordService.update(this.id).subscribe((res) => {
  //     this.router.navigateByUrl('/webdesign');
  //     this.toastr.success('修改finished成功');
  //   }, (error) => {
  //     this.toastr.error(error.error);
  //   })
  // }

  isChecked(id) {
    // this.designRecordService.getRecordById(id).subscribe(res => {
    //   this.designRecord = res;
    //   this.finished = !res.finished;
    // });

    this.designRecordService.setFinished(id).subscribe((res) => {
      // res.finished = this.finished;
      this.router.navigateByUrl('/webdesign');
      this.toastr.success('修改finished成功');
    }, (error) => {
      this.toastr.error(error.error);
    })
  }

}
