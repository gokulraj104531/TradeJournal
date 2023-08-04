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
import { AuthClassGuard } from './auth-class.guard';


const routes: Routes = [
  {path:'main',component:MainComponent,canActivate:[AuthClassGuard]},
  {path:'login',component:LoginComponent},
  {path:'signup',component:SignupComponent},
  {path:'dashboard',component:DashboardComponent,canActivate:[AuthClassGuard]},
  {path:"charts",component:ChartsComponent,canActivate:[AuthClassGuard]},
  {path:'calendar',component:CalendarComponent,canActivate:[AuthClassGuard]},
  {path:'addjournal/:journalId',component:AddjournalComponent,canActivate:[AuthClassGuard]},
  {path:"viewjournal",component:ViewjournalComponent,canActivate:[AuthClassGuard]},
  {path:"addjournal",component:AddjournalComponent,canActivate:[AuthClassGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
