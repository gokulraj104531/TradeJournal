import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { SignupComponent } from './pages/signup/signup.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ChartsComponent } from './components/charts/charts.component';
import { AddjournalComponent } from './components/addjournal/addjournal.component';
import { ViewjournalComponent } from './components/viewjournal/viewjournal.component';
import { CalendarComponent } from './components/calendar/calendar.component';
import { MainComponent } from './components/main/main.component';


const routes: Routes = [
  {path:'main',component:MainComponent},
  {path:'login',component:LoginComponent},
  {path:'signup',component:SignupComponent},
  {path:'dashboard',component:DashboardComponent},
  {path:"charts",component:ChartsComponent},
  {path:'calendar',component:CalendarComponent},
  {path:"addjournal",component:AddjournalComponent},
  {path:"viewjournal",component:ViewjournalComponent},
  {path:"addjournal",component:AddjournalComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
