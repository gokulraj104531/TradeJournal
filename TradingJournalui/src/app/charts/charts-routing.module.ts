import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChartsComponent } from './charts.component';
import { MainLayoutComponent } from '../layouts/main-layout/main-layout.component';

const routes: Routes = [
  {
    path: 'charts',
    component: MainLayoutComponent,
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
