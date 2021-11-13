import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IMember } from './member';
import { map, take } from 'rxjs/operators';
import { UserParams } from './userParams';
import { AccountService } from '../account.service';
import { getPaginatedResult, getPaginationHeaders } from '../../_services/paginationHelper';
import { Observable, of } from 'rxjs';
import { PaginatedResult } from '../../_models/pagination';
import { ILoggedUser } from '../loggedUser';
import { IUserImageUpdate } from './userImageUpdate';

@Injectable({
  providedIn: 'root'
})
export class MembersService {
  baseUrl = environment.apiUrl;
  imageUrl = environment.url;

  members: IMember[] = [];
  member: IMember;
  // paginatedResult: PaginatedResult<Member[]> = new PaginatedResult<Member[]>();
  loggerUser: ILoggedUser;
  memberCache = new Map();
  userParams: UserParams;
  userImageUpdate: IUserImageUpdate;

  constructor(private http: HttpClient, private accountService: AccountService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => {
      this.loggerUser = user;
      this.userParams = new UserParams(user);
    })
  }

  getUserParams() {
    return this.userParams;
  }

  setUserParams(params: UserParams) {
    this.userParams = params;
  }

  resetUserParams() {
    this.userParams = new UserParams(this.loggerUser);
    return this.userParams;
  }

  // getMembers(page?: number, itemsPerPage?: number) {
  //   let params = new HttpParams();

  //   if (page !== null && itemsPerPage !== null) {
  //     params = params.append('pageNumber', page.toString());
  //     params = params.append('pageSize', itemsPerPage.toString());
  //   }
  //   // ******   if (this.members.length > 0) return of(this.members);   //members的数据存储在页面，只有不存在时才需要从服务器获得
  //   return this.http.get<Member[]>(this.baseUrl + 'api/users', { observe: 'response', params }).pipe(
  //     //**** map(members => {
  //     //   this.members = members;
  //     //   return members;
  //     // })
  //     map(response => {
  //       this.paginatedResult.result = response.body;
  //       if (response.headers.get('Pagination') !== null) {
  //         this.paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
  //       }
  //       return this.paginatedResult;
  //     })
  //   )
  // }

  getMembers(userParams: UserParams) {
    var response = this.memberCache.get(Object.values(userParams).join('-'));
    if (response) {
      return of(response);
    }

    let params = getPaginationHeaders(userParams.pageNumber, userParams.pageSize);

    params = params.append('minAge', userParams.minAge.toString());
    params = params.append('maxAge', userParams.maxAge.toString());
    params = params.append('gender', userParams.gender);
    params = params.append('orderBy', userParams.orderBy);

    return getPaginatedResult<IMember[]>(this.baseUrl + '/users', params, this.http)
      .pipe(map(response => {
        this.memberCache.set(Object.values(userParams).join('-'), response);
        return response;
      }))
  }

  getMember(username: string) {
    // const member = this.members.find(x => x.username === username);
    // if (member !== undefined) return of(member);
    const member = [...this.memberCache.values()]
      .reduce((arr, elem) => arr.concat(elem.result), [])
      .find((member: IMember) => member.username === username);

    if (member) {
      return of(member);
    }

    return this.http.get<IMember>(this.baseUrl + '/users/' + username)
  }

  updateMember(member: IMember) {
    return this.http.put(this.baseUrl + '/users', member).pipe(
      map(() => {
        const index = this.members.indexOf(member);
        this.members[index] = member;
      })
    )
  }

  uploadImage(username, date): Observable<any> {
    return this.http.put(this.baseUrl + '/users/patch/' + username, date);
  }

  //  { 'profilePicture': profilePicture }

  setMainPhoto(photoId: number) {
    return this.http.put(this.baseUrl + '/users/set-main-photo/' + photoId, {});
  }

  deletePhoto(photoId: number) {
    return this.http.delete(this.baseUrl + '/users/delete-photo/' + photoId);
  }

  addLike(username: string) {
    return this.http.post(this.baseUrl + '/likes/' + username, {})
  }

  getLikes(predicate: string, pageNumber, pageSize) {
    let params = getPaginationHeaders(pageNumber, pageSize);
    params = params.append('predicate', predicate);
    return getPaginatedResult<Partial<IMember[]>>(this.baseUrl + '/likes', params, this.http);
  }


}
