import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable, Subject } from 'rxjs';

import { IUser } from '../model/User';
import { environment } from '../../environments/environment'

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private loggedIn: BehaviorSubject<boolean>;
  private loggedUser: BehaviorSubject<IUser>;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  constructor(
    private httpClient: HttpClient
  ) {
    this.loggedIn = new BehaviorSubject<boolean>(this.hasUserInStorage());
    this.loggedUser = new BehaviorSubject<IUser>(this.getUserFromStorage());
  }

  public loginUser(user: IUser) {
    return this.httpClient.post<IUser>(environment.base + 'api/auth/login', user, this.httpOptions).subscribe(
      data => {
        localStorage.setItem('user', JSON.stringify(data));
        this.loggedIn.next(true);
        this.loggedUser.next(data);
      }
    );
  }

  public logout() {
    this.httpClient.post(environment.base + 'api/auth/logout', null, this.httpOptions);
    localStorage.removeItem('user');
    this.loggedIn.next(false);
    this.loggedUser.next(null);
  }

  public getLoggedInObservable() {
    return this.loggedIn.asObservable();
  }

  public getLoggedUserObservable() {
    return this.loggedUser.asObservable();
  }

  private getUserFromStorage() {
    if (this.hasUserInStorage) {
      return JSON.parse(localStorage.getItem('user'))
    }
    return null;
  }

  private hasUserInStorage(): boolean {
    return !!localStorage.getItem('user');
  }

}
