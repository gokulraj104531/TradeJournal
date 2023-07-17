import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { Route } from '@angular/router';

@Injectable({
  providedIn: 'root'
})

export class AuthClassGuard implements CanActivate {
 
  namme=sessionStorage.getItem("UserName");
 
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      if(this.namme==null){
        return false;
        // this.router.navigateByUrl("/dashboard");
      }
      else{
        return true;
      }
   
  }
  
}
