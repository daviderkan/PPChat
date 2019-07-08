import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment'
import { IMessage } from '../model/Message';

@Injectable({
  providedIn: 'root'
})
export class ChatService {

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  constructor(
    private httpClient: HttpClient
  ) { }

  public get$() {
    //return this.httpClient.get(environment.base + 'messages', this.httpOptions);
    return this.httpClient.get<IMessage[]>(environment.base + 'api/messages', this.httpOptions);
  }

  public create$(msg: IMessage) {
    return this.httpClient.post<IMessage>(environment.base + 'api/messages/add', msg, this.httpOptions);
  }

}
