import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IUser } from '../model/User';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  constructor(
    private httpClient: HttpClient
  ) { }

  registerUser(user: IUser) {
    return this.httpClient.post<IUser>('http://localhost:5000/api/users/register', user, this.httpOptions).subscribe(
      data => console.log(data),
      error => console.log(error)
    );
  }
}
