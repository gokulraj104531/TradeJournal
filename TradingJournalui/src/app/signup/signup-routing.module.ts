import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { SignupComponent } from './signup.component';
import { AuthComponent } from '../layouts/auth/auth.component';

const routes: Routes = [
  {
    path:'register',
    component:AuthComponent,
    children:[
      {
        path:'',component:SignupComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SignupRoutingModule { }
