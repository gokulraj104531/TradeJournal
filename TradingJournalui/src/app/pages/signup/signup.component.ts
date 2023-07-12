import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { UserRegisteration } from 'src/models/UserRegisteration';
import { HttpservicesService } from 'src/services/httpservices.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent  {
 

  Userarray: UserRegisteration[] = [];
  Userformgroup: FormGroup;

  constructor(private userregservice: HttpservicesService, private fb: FormBuilder,private router:Router) {
    this.Userformgroup = this.fb.group({
      UserName: [""],
      Name: [""],
      Email: [""],
      Password: [""],
      PhoneNumber: [""]
    })
  }
  
  onSubmit() {
    this.userregservice.AddUser(this.Userformgroup.value).subscribe(response => {
      console.log(response);
      this.Userformgroup.setValue({
        UserName: "",
        Name: "",
        Email: "",
        Password: "",
        PhoneNumber: ""
      })
      this.router.navigateByUrl('/login');
    });
 
  }
}