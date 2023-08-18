import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthComponent } from '../layouts/auth/auth.component';

const routes: Routes = [
  {
    path:'login',
    component:AuthComponent,
    children:[
      {
        path:'',component:LoginComponent
      },
    ]
  }
  
];

@NgModule({
  imports: [RouterModule.forChild(routes),ReactiveFormsModule],
  exports: [RouterModule]
})
export class LoginRoutingModule { }
