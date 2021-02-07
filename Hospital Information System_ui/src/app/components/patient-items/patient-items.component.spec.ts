import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PatientItemsComponent } from './patient-items.component';

describe('PatientItemsComponent', () => {
  let component: PatientItemsComponent;
  let fixture: ComponentFixture<PatientItemsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PatientItemsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PatientItemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
