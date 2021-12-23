import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppointmentsInfoTableComponent } from './appointments-info-table.component';

describe('AppointmentsInfoTableComponent', () => {
  let component: AppointmentsInfoTableComponent;
  let fixture: ComponentFixture<AppointmentsInfoTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AppointmentsInfoTableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AppointmentsInfoTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
