import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
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
loginformgroup!:FormGroup;

constructor(private loginservice:HttpservicesService,private log:FormBuilder,private router:Router){
this.loginformgroup=this.log.group({
  UserName:new FormControl('',Validators.required),
  Password:new FormControl('',Validators.required),
});
}
onlogin(){
  this.loginservice.Login(this.loginformgroup.value.UserName,this.loginformgroup.value.Password).subscribe((token:string)=>{
     sessionStorage.setItem("UserName",this.loginformgroup.value.UserName);
     localStorage.setItem('authtoken',token);
    if(token==null){
      alert("enter the correct Username or Password");
    }
    else{
      this.router.navigateByUrl("/main");
    }
   
  },
  (error)=>{
    console.warn(error)
    alert("Stay relax and Enter Your Data in text box first")
  });
}
  
}
