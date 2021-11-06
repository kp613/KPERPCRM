import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Observable } from 'rxjs';
import { ILoggedUser } from 'src/app/account/loggedUser';
import { IMember } from 'src/app/account/members/member';
import { IPagination } from 'src/app/_models/pagination';
import { UserParams } from 'src/app/account/members/userParams';
import { MembersService } from 'src/app/account/members/members.service';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.scss']
})
export class MemberListComponent implements OnInit {
  // members$: Observable<Member[]>;
  members: IMember[];
  pagination: IPagination;

  // pageNumber = 1;
  pageSize = 60;

  userParams: UserParams;
  user: ILoggedUser;
  genderList = [{ value: 'male', display: '男' }, { value: 'female', display: '女' }];

  constructor(private memberService: MembersService, private http: HttpClient, private title: Title) {
    this.userParams = this.memberService.getUserParams();
  }

  ngOnInit(): void {
    this.title.setTitle("员工管理 - 科朗管理平台");
    // this.members$ = this.memberService.getMembers();
    this.loadMembers();
  }

  loadMembers() {
    this.memberService.setUserParams(this.userParams);
    this.userParams.pageSize = this.pageSize;
    this.memberService.getMembers(this.userParams).subscribe(response => {
      // this.memberService.getMembers(this.pageNumber, this.pageSize).subscribe(response => {
      this.members = response.result;
      this.pagination = response.pagination;
    })
  }

  resetFilters() {
    this.userParams = this.memberService.resetUserParams();
    this.loadMembers();
  }

  pageChanged(event: any) {
    this.userParams.pageNumber = event.page;
    this.memberService.setUserParams(this.userParams);
    this.loadMembers();
  }
}
