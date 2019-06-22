import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

import { RegisterService } from '../services/register.service';
import { IUser } from "../model/User";

@Component({
  selector: 'app-register',
  templateUrl: 'register.component.html',
  styleUrls: ['register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;

  constructor(
    private registerService: RegisterService,
    private formBuilder: FormBuilder
  ) {

    this.registerForm = this.formBuilder.group({
      name: '',
      password: ''
    });

  }

  ngOnInit() {
  }

  onSubmit(formValue) {
    let user: IUser = {
      name: formValue.name,
      password: formValue.password
    };

    this.registerService.registerUser(user);
  }

}
