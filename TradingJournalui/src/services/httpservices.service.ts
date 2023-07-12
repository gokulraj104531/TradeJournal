import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserRegisteration } from 'src/models/UserRegisteration';
import {Observable} from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class HttpservicesService {

  constructor(private httpclient:HttpClient) {}
  baseurl="https://localhost:7012/";


//Signup page
  AddUser(user:UserRegisteration):Observable<UserRegisteration>{
    return this.httpclient.post<UserRegisteration>(this.baseurl+"api/UserRegistration/AddUser",user);
  }

//Login page
 Login(username:String,password:String){
  return this.httpclient.get(this.baseurl+"api/UserRegistration/Login/"+username+"/"+password);

}
}