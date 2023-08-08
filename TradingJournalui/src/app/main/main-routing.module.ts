import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainLayoutComponent } from '../layouts/main-layout/main-layout.component';
import { MainComponent } from './main.component';

const routes: Routes = [
  {
    path: 'main',
    component: MainLayoutComponent,
    children: [
      {
        path: '',
        component: MainComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MainRoutingModule {}
