import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { Editor, Toolbar } from 'ngx-editor';
import { Observable } from 'rxjs';
import { DesignRecordService } from '../design-record.service';
import { IDesignRecord } from '../design-recore';

@Component({
  selector: 'app-design-record-list',
  templateUrl: './design-record-list.component.html',
  styleUrls: ['./design-record-list.component.scss']
})
export class DesignRecordListComponent implements OnInit {

  designRecords: IDesignRecord[];

  constructor(private designRecordService: DesignRecordService) { }

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

}
