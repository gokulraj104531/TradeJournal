import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})

export class AuthClassGuard implements CanActivate {

  constructor(private route:Router){}
 
  namme=sessionStorage.getItem("UserName");
 
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      if(this.namme==null){
        this.route.navigateByUrl("/login");
        return false;
      }
      else{
        return true;
      }
   
  } 
}
