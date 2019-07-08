import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

import { UserService } from '../../services/user.service';
import { AuthService } from '../../services/auth.service';
import { IUser } from "../../model/User";
import { Observable, Subscription } from 'rxjs';

@Component({
  selector: 'app-register',
  templateUrl: 'register.component.html',
  styleUrls: ['register.component.css']
})
export class RegisterComponent implements OnInit, OnDestroy {

  registerForm: FormGroup;
  loggedUser$: Observable<IUser>;
  loggedIn$: Observable<boolean>;

  loggedInSubscription: Subscription;

  constructor(
    private authService: AuthService,
    private userService: UserService,
    private formBuilder: FormBuilder,
    private router: Router
  ) {

    this.registerForm = this.formBuilder.group({
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

    this.userService.registerUser(user);
  }

  ngOnInit() {

  }

  ngOnDestroy() {
    this.loggedInSubscription.unsubscribe();
  }

}
