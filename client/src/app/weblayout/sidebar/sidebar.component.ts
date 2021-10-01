import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ILoggedUser } from 'src/app/account/loggedUser';
import { AccountService } from 'src/app/account/account.service';
import { environment } from 'src/environments/environment';
// import { version } from '../../package.json';
// import { Version } from '@angular/compiler';


@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
  version = environment.appVersion;

  constructor() { }

  ngOnInit(): void {
  }

}
