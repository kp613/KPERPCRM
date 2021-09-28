import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ILoggedUser } from './account/loggedUser';
import { AccountService } from './account/account.service';

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
    const user: ILoggedUser = JSON.parse(localStorage.getItem('user'));
    this.accountService.setCurrentUser(user);
  }

}
