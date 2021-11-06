import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IMessage } from './message';
import { getPaginatedResult, getPaginationHeaders } from '../../_services/paginationHelper';

@Injectable({
  providedIn: 'root'
})
export class MessageService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getMessages(pageNumber, pageSize, container) {
    let params = getPaginationHeaders(pageNumber, pageSize);
    params = params.append('Container', container);
    return getPaginatedResult<IMessage[]>(this.baseUrl + '/messages', params, this.http);
  }

  getMessageThread(username: string) {
    return this.http.get<IMessage[]>(this.baseUrl + '/messages/thread/' + username);
  }

  sendMessage(username: string, content: string) {
    return this.http.post<IMessage>(this.baseUrl + '/messages', { recipientUsername: username, content })
  }

  deleteMessage(id: number) {
    return this.http.delete(this.baseUrl + '/messages/' + id);
  }
}
