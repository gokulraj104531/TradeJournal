import { Component } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent {
  name:any;
constructor (private router:Router)
{
  this.name=sessionStorage.getItem("UserName");
}
LogOut(){
  this.router.navigateByUrl("/login");
}
}
