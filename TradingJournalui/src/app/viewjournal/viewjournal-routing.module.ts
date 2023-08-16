import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainLayoutComponent } from '../layouts/main-layout/main-layout.component';
import { ViewjournalComponent } from './viewjournal.component';
import { AuthClassGuard } from '../auth-class.guard';

const routes: Routes = [
  {
    path: 'viewjournal',
    component: MainLayoutComponent,
    canActivate:[AuthClassGuard],
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
