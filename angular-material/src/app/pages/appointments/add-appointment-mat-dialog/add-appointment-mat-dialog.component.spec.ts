import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddAppointmentMatDialogComponent } from './add-appointment-mat-dialog.component';

describe('AddAppointmentMatDialogComponent', () => {
  let component: AddAppointmentMatDialogComponent;
  let fixture: ComponentFixture<AddAppointmentMatDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddAppointmentMatDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddAppointmentMatDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
