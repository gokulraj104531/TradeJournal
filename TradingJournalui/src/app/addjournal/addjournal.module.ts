import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AddjournalRoutingModule } from './addjournal-routing.module';
import { AddjournalComponent } from './addjournal.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [AddjournalComponent],
  imports: [
    CommonModule,
    AddjournalRoutingModule,
    ReactiveFormsModule
  ]
})
export class AddjournalModule { }
