import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainLayoutComponent } from '../layouts/main-layout/main-layout.component';
import { ViewjournalComponent } from './viewjournal.component';

const routes: Routes = [
  {
    path: 'viewjournal',
    component: MainLayoutComponent,
    children: [
      {
        path: '',
        component: ViewjournalComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ViewjournalRoutingModule { }
