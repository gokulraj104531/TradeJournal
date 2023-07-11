import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { UserRegisteration } from 'src/models/UserRegisteration';
import { HttpservicesService } from 'src/services/httpservices.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

loginarray:UserRegisteration[]=[];
loginformgroup:FormGroup;

constructor(private loginservice:HttpservicesService,private log:FormBuilder,private router:Router){
this.loginformgroup=this.log.group({
  UserName:[""],
  Password:[""]
})
}

onlogin(){
  this.loginservice.Login(this.loginformgroup.value.UserName,this.loginformgroup.value.Password).subscribe(response=>{
    if(response==null){
      alert("enter the correct Username or Password");
    }
    else{
      this.router.navigate(['/sidebar']);
    }
   
  },
  (error)=>{
    alert("Stay relax and Enter Your Data in text box first")
  });
}
  
}
