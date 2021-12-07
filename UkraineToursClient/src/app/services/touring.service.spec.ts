import { TestBed } from '@angular/core/testing';

import { TouringService } from './touring.service';

describe('TouringService', () => {
  let service: TouringService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TouringService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
