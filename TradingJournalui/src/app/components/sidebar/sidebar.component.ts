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
  sessionStorage.removeItem("UserName");
  localStorage.removeItem('authtoken')
  this.router.navigateByUrl("/login");
}
routers()
{
  this.router.navigateByUrl('/viewjournal')
}
}
