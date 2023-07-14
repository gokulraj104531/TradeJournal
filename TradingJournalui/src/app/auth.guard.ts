import { CanActivateFn } from '@angular/router';

export const authGuard: CanActivateFn = (route, state) => {

  
  return true;
  // if(sessionStorage.getItem!=null){
  //   return true;
  // }
  // else{
  //   return false;
  // }
};
