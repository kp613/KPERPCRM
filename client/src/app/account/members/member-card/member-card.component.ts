import { Component, Input, OnInit } from '@angular/core';
import { YEAR } from 'ngx-bootstrap/chronos/units/constants';
import { DateInputComponent } from 'src/app/_shared/components/forms/date-input/date-input.component';
import { IMember } from 'src/app/account/members/member';

@Component({
  selector: 'app-member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.scss']
})
export class MemberCardComponent implements OnInit {
  @Input() member: IMember;
  currentDate: Date = new Date();

  constructor() { }

  ngOnInit(): void {
  }

  lockoutEnd() {
    if (this.member.lockoutEnd.getDay() > this.currentDate.getDay() + 1 && this.member.lockoutEnd != null) return true;
    return false;
  }

  beOnLeaveEnd() {
    if (this.member.beOnLeaveEnd.getTime() > this.currentDate.getTime()) return true;
    return false;
  }

}
