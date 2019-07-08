import { Component, OnInit, OnDestroy } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { Router } from '@angular/router';

import { AuthService } from '../../services/auth.service';
import { IUser } from '../../model/User';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, OnDestroy {

  loggedUser$: Observable<IUser>;
  loggedIn$: Observable<boolean>;

  loggedInSubscription: Subscription;


  constructor(
    private authService: AuthService,
    private router: Router
  ) {

    this.loggedIn$ = this.authService.getLoggedInObservable();
    this.loggedUser$ = this.authService.getLoggedUserObservable();

    this.loggedInSubscription = this.loggedIn$.subscribe(
      loggedIn => {
        if (loggedIn == false)
          this.router.navigate(['/login']);
      }
    )

  }

  ngOnInit() {
  }

  ngOnDestroy() {
    this.loggedInSubscription.unsubscribe();
  }

}
