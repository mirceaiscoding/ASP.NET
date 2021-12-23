import { TestBed } from '@angular/core/testing';

import { AuthorizeRequestInterceptor } from './authorize-request.interceptor';

describe('AuthorizeRequestInterceptor', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      AuthorizeRequestInterceptor
      ]
  }));

  it('should be created', () => {
    const interceptor: AuthorizeRequestInterceptor = TestBed.inject(AuthorizeRequestInterceptor);
    expect(interceptor).toBeTruthy();
  });
});
