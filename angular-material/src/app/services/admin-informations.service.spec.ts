import { TestBed } from '@angular/core/testing';

import { AdminInformationsService } from './admin-informations.service';

describe('AdminInformationsService', () => {
  let service: AdminInformationsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AdminInformationsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
