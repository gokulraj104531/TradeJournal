import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainLayoutComponent } from './main-layout/main-layout.component';
import { HeaderComponent } from './header/header.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { RouterModule } from '@angular/router';
import { AuthComponent } from './auth/auth.component';



@NgModule({
  declarations: [
    MainLayoutComponent,
    HeaderComponent,
    SidebarComponent,
    AuthComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([])
  ],
  exports:[
    MainLayoutComponent,
    AuthComponent
  ]
})
export class LayoutModule { }
