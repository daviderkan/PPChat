import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IUser } from '../model/User';
import { AuthService } from './auth.service';
import { environment } from '../../environments/environment'

@Injectable({
  providedIn: 'root'
})
export class UserService {

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  constructor(
    private httpClient: HttpClient,
    private authService: AuthService
  ) {

  }

  registerUser(user: IUser) {
    return this.httpClient.post<IUser>(environment.base + 'api/users/register', user, this.httpOptions).subscribe(
      data => {
        console.log(data);
        this.authService.loginUser(data);
      },
      error => console.log(error)
    );
  }
}
