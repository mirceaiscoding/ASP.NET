import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddProcedureDialogComponent } from './add-procedure-dialog.component';

describe('AddProcedureDialogComponent', () => {
  let component: AddProcedureDialogComponent;
  let fixture: ComponentFixture<AddProcedureDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddProcedureDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddProcedureDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
