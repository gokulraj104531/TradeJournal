import { Component, OnDestroy } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  MinLengthValidator,
  Validators,
} from '@angular/forms';
import { UserRegisteration } from 'src/models/UserRegisteration';
import { HttpservicesService } from 'src/services/httpservices.service';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  loginarray: UserRegisteration[] = [];
  loginformgroup!: FormGroup;
  login!: Subscription;

  constructor(
    private loginservice: HttpservicesService,
    private log: FormBuilder,
    private router: Router
  ) {
    this.loginformgroup = this.log.group({
      UserName: new FormControl('', Validators.required),
      Password: new FormControl('', [
        Validators.required,
        Validators.minLength(8),
      ]),
    });
  }

  onlogin() {
    this.login = this.loginservice
      .Login(
        this.loginformgroup.value.UserName,
        this.loginformgroup.value.Password
      )
      .subscribe(
        (token: any) => {
          sessionStorage.setItem(
            'UserName',
            this.loginformgroup.value.UserName
          );
          localStorage.setItem('authtoken', token);
          if (token == null) {
            alert(' Either Your Username or Password is wrong');
          } else {
            this.router.navigateByUrl('/main');
          }
        },
        (error) => {
          console.warn(error);
          alert('Check Your Username or Password or API connection');
        }
      );
  }
}
