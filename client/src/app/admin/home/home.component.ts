import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/account/account.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  registerMode = false;

  constructor(public accountService: AccountService) { }

  ngOnInit(): void {

  }

  regFromLoginMode(event: boolean) {
    this.registerMode = event;
  }

}
