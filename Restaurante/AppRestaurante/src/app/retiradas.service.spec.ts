import { TestBed } from '@angular/core/testing';

import { RetiradasService } from './retiradas.service';

describe('RetiradasService', () => {
  let service: RetiradasService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RetiradasService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
