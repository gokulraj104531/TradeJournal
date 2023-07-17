import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { UserRegisteration } from 'src/models/UserRegisteration';
import { HttpservicesService } from 'src/services/httpservices.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css'],
})
export class SignupComponent {
  Userarray: UserRegisteration[] = [];
  Userformgroup: FormGroup;

  constructor(
    private userregservice: HttpservicesService,
    private fb: FormBuilder,
    private router: Router
  ) {
    this.Userformgroup = this.fb.group({
      UserName:new FormControl ('',Validators.required),
      Name: new FormControl ('',Validators.required),
      Email:new FormControl ('',[Validators.required,Validators.email]),
      Password:new FormControl ('',[Validators.required,Validators.minLength(8)]),
      PhoneNumber: new FormControl ('',Validators.required),
    });
  }

  onSubmit() {
    this.userregservice
      .AddUser(this.Userformgroup.value)
      .subscribe((response) => {
        console.log(response);
        this.Userformgroup.setValue({
          UserName: '',
          Name: '',
          Email: '',
          Password: '',
          PhoneNumber: '',
        });
        this.router.navigateByUrl('/login');
      });
  }
}
