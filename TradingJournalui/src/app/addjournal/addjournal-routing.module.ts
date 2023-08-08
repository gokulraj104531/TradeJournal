import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainLayoutComponent } from '../layouts/main-layout/main-layout.component';
import { AddjournalComponent } from './addjournal.component';

const routes: Routes = [ {
  path: 'addjournal/:journalId',
  component: MainLayoutComponent,
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
