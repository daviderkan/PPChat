import { Component, OnInit, OnDestroy } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Observable, Subscription } from 'rxjs';
import { IUser } from '../../model/User';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit{

  loggedUser$: Observable<IUser>;
  loggedIn$: Observable<boolean>;

  constructor(
    private authService: AuthService
  ) {
    this.loggedUser$ = authService.getLoggedUserObservable();
    this.loggedIn$ = authService.getLoggedInObservable();
  }

  ngOnInit() {
  }

  public logout() {
    this.authService.logout();
  }

}
