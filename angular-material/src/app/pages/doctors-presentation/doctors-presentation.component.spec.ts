import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DoctorsPresentationComponent } from './doctors-presentation.component';

describe('DoctorsPresentationComponent', () => {
  let component: DoctorsPresentationComponent;
  let fixture: ComponentFixture<DoctorsPresentationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DoctorsPresentationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DoctorsPresentationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
