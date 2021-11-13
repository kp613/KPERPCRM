import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-setting-sidebar',
  templateUrl: './setting-sidebar.component.html',
  styleUrls: ['./setting-sidebar.component.scss']
})
export class SettingSidebarComponent implements OnInit {
  production = environment.production;  //判断是否为生产状态

  constructor() { }

  ngOnInit(): void {
  }

}
