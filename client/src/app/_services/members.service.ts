import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Member } from '../_models/member';
import { map, take } from 'rxjs/operators';
import { UserParams } from '../_models/userParams';
import { AccountService } from './account.service';
import { getPaginatedResult, getPaginationHeaders } from './paginationHelper';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MembersService {
  baseUrl = environment.apiUrl;
  members: Member[] = [];
  memberCache = new Map();
  userParams: UserParams;

  constructor(private http: HttpClient, private accountService: AccountService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => {
      this.userParams = new UserParams(user);
    })
  }

  getMembers() {
    if (this.members.length > 0) return of(this.members);
    return this.http.get<Member[]>(this.baseUrl + 'api/users').pipe(
      map(members => {
        this.members = members;
        return members;
      })
    )
  }

  getMember(username: string) {
    const member = this.members.find(x => x.username === username);
    if (member !== undefined) return of(member);
    return this.http.get<Member>(this.baseUrl + 'api/users/' + username)
  }

  getUserParams() {
    return this.userParams;
  }

  setUserParams(params: UserParams) {
    this.userParams = params;
  }

  // resetUserParams() {
  //   this.userParams = new UserParams(this.user);
  //   return this.userParams;
  // }

  // getMembers(userParams: UserParams) {
  //   var response = this.memberCache.get(Object.values(userParams).join('-'));
  //   if (response) {
  //     return of(response);
  //   }

  //   let params = getPaginationHeaders(userParams.pageNumber, userParams.pageSize);

  //   params = params.append('minAge', userParams.minAge.toString());
  //   params = params.append('maxAge', userParams.maxAge.toString());
  //   params = params.append('gender', userParams.gender);
  //   params = params.append('orderBy', userParams.orderBy);

  //   return getPaginatedResult<Member[]>(this.baseUrl + 'users', params, this.http)
  //     .pipe(map(response => {
  //       this.memberCache.set(Object.values(userParams).join('-'), response);
  //       return response;
  //     }))
  // }

  // getMember(username: string) {
  //   const member = [...this.memberCache.values()]
  //     .reduce((arr, elem) => arr.concat(elem.result), [])
  //     .find((member: Member) => member.username === username);

  //   if (member) {
  //     return of(member);
  //   }
  //   return this.http.get<Member>(this.baseUrl + 'users/' + username);
  // }

  updateMember(member: Member) {
    return this.http.put(this.baseUrl + 'api/users', member).pipe(
      map(() => {
        const index = this.members.indexOf(member);
        this.members[index] = member;
      })
    )
  }

  setMainPhoto(photoId: number) {
    return this.http.put(this.baseUrl + 'users/set-main-photo/' + photoId, {});
  }

  deletePhoto(photoId: number) {
    return this.http.delete(this.baseUrl + 'users/delete-photo/' + photoId);
  }

  addLike(username: string) {
    return this.http.post(this.baseUrl + 'likes/' + username, {})
  }

  getLikes(predicate: string, pageNumber, pageSize) {
    let params = getPaginationHeaders(pageNumber, pageSize);
    params = params.append('predicate', predicate);
    return getPaginatedResult<Partial<Member[]>>(this.baseUrl + 'likes', params, this.http);
  }


}
