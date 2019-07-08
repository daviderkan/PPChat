import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';

import { AuthService } from '../../services/auth.service';
import { IUser } from "../../model/User";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, OnDestroy {

  loginForm: FormGroup;
  loggedUser$: Observable<IUser>;
  loggedIn$: Observable<boolean>;

  loggedInSubscription: Subscription;

  constructor(
    private authService: AuthService,
    private formBuilder: FormBuilder,
    private router: Router
  ) {
    this.loginForm = this.formBuilder.group({
      name: '',
      password: ''
    });

    this.loggedUser$ = this.authService.getLoggedUserObservable();
    this.loggedIn$ = this.authService.getLoggedInObservable();

    this.loggedInSubscription = this.loggedIn$.subscribe(
      loggedIn => {
        if (loggedIn == true)
          this.router.navigate(['/home']);
      }
    )

  }

  onSubmit(formValue) {

    let user: IUser = {
      name: formValue.name,
      password: formValue.password
    };

    this.authService.loginUser(user);
  }

  ngOnInit() {
  }

  ngOnDestroy() {
    this.loggedInSubscription.unsubscribe();
  }

}
