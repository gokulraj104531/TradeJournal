import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainLayoutComponent } from '../layouts/main-layout/main-layout.component';
import { AddjournalComponent } from './addjournal.component';
import { AuthClassGuard } from '../auth-class.guard';

const routes: Routes = [ {
  path: 'addjournal/:journalId',
  component: MainLayoutComponent,
  canActivate:[AuthClassGuard],
  children: [
    {
      path: '',
      component: AddjournalComponent,
    },
  ],
},];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AddjournalRoutingModule { }
