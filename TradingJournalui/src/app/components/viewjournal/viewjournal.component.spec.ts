import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewjournalComponent } from './viewjournal.component';

describe('ViewjournalComponent', () => {
  let component: ViewjournalComponent;
  let fixture: ComponentFixture<ViewjournalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ViewjournalComponent]
    });
    fixture = TestBed.createComponent(ViewjournalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
