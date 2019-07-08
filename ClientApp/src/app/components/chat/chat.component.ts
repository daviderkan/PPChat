import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';

import { HubConnection } from '@aspnet/signalr';
import * as signalR from '@aspnet/signalr';

import { AuthService } from '../../services/auth.service';
import { ChatService } from '../../services/chat.service';
import { IMessage } from '../../model/Message';
import { IUser } from '../../model/User';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements OnInit, OnDestroy {

  private messages: IMessage[];
  private user: IUser;

  messages$: BehaviorSubject<IMessage[]>;
  sendMsgForm: FormGroup;
  chatHubConnection: HubConnection;

  constructor(
    private authService: AuthService,
    private chatService: ChatService,
    private formBuilder: FormBuilder,
    private router: Router
  ) {
    this.messages$ = new BehaviorSubject<IMessage[]>(this.messages);
  }

  ngOnInit() {

    this.chatService.get$().subscribe(
      val => {
        this.messages = val;
        this.messages$.next(this.messages);
      });

    this.chatHubConnection = new signalR.HubConnectionBuilder().withUrl('/chatHub').build();

    this.chatHubConnection.on('ReceiveMessage', msg => this.insertMessage(msg));

    this.chatHubConnection.start().then(function () {
      console.log('connection started');
    }).catch(function (err) {
      return console.error(err.toString());
    });

    this.sendMsgForm = this.formBuilder.group({
      msg: '',
    });

    this.sendMsgForm.disable();

    this.authService.getLoggedUserObservable().subscribe(
      user => {
        if (user)
          this.user = user;
        this.sendMsgForm.enable();
      });
    
  }

  ngOnDestroy() {

  }

  /*ReceiveMessage(msg: IMessage) {
    this.insertMessage(msg);
  }*/

  onSubmit(formvalue) {
    let msg: IMessage = {
      content: formvalue.msg,
      creationTime: new Date(),
      author: this.user.name
    };

    this.chatService.create$(msg).subscribe(
      value => {
        this.chatHubConnection.invoke('SendMessage', value)
          .catch(e => console.log(e));
      });
  }

  insertMessage(msg: IMessage) {
    this.messages.push(msg);
  } 

}
