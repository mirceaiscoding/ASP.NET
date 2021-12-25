import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChooseTimeIntervalMatDialogComponent } from './choose-time-interval-mat-dialog.component';

describe('ChooseTimeIntervalMatDialogComponent', () => {
  let component: ChooseTimeIntervalMatDialogComponent;
  let fixture: ComponentFixture<ChooseTimeIntervalMatDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChooseTimeIntervalMatDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ChooseTimeIntervalMatDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
