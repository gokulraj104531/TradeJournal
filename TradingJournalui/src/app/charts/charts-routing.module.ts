import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChartsComponent } from './charts.component';
import { MainLayoutComponent } from '../layouts/main-layout/main-layout.component';
import { AuthClassGuard } from '../auth-class.guard';

const routes: Routes = [
  {
    path: 'charts',
    component: MainLayoutComponent,
    canActivate:[AuthClassGuard],
    children: [
      {
        path: '',
        component: ChartsComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ChartsRoutingModule { }
