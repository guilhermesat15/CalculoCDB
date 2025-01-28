import { TestBed } from '@angular/core/testing';

import { CalculadorCDBService } from './calculador-cdb.service';

describe('CalculadorCDBService', () => {
  let service: CalculadorCDBService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CalculadorCDBService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
