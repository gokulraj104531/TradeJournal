import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CalendarComponent } from './calendar.component';
import { MainLayoutComponent } from '../layouts/main-layout/main-layout.component';

const routes: Routes = [
  {
    path: 'calendar',
    component: MainLayoutComponent,
    children: [
      {
        path: '',
        component:CalendarComponent ,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CalendarRoutingModule { }
