import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ViewjournalRoutingModule } from './viewjournal-routing.module';
import { ViewjournalComponent } from './viewjournal.component';


@NgModule({
  declarations: [ViewjournalComponent],
  imports: [
    CommonModule,
    ViewjournalRoutingModule
  ]
})
export class ViewjournalModule { }
