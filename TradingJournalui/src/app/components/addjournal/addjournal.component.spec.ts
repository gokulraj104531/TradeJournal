import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddjournalComponent } from './addjournal.component';

describe('AddjournalComponent', () => {
  let component: AddjournalComponent;
  let fixture: ComponentFixture<AddjournalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddjournalComponent]
    });
    fixture = TestBed.createComponent(AddjournalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
