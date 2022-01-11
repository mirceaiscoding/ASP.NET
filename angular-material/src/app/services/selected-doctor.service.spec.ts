import { TestBed } from '@angular/core/testing';

import { SelectedDoctorService } from './selected-doctor.service';

describe('SelectedDoctorService', () => {
  let service: SelectedDoctorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SelectedDoctorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
