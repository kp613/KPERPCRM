import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-setting-home',
  templateUrl: './setting-home.component.html',
  styleUrls: ['./setting-home.component.scss']
})
export class SettingHomeComponent implements OnInit {
  production = environment.production;  //判断是否为生产状态

  constructor() { }

  ngOnInit(): void {

  }




}
