import { TestBed } from '@angular/core/testing';

import { PublicInformationsService } from './public-informations.service';

describe('PublicInformationsService', () => {
  let service: PublicInformationsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PublicInformationsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
