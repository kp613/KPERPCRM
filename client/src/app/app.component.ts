import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { LoggedUser } from './_models/loggedUser';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = '南京科朗医药化工有限公司';
  thisTime = Date.now();


  constructor(public accountService: AccountService) { }

  ngOnInit() {
    this.setCurrentUser();
  }

  setCurrentUser() {
    const user: LoggedUser = JSON.parse(localStorage.getItem('user'));
    this.accountService.setCurrentUser(user);
  }
}
