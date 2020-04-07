import { TestBed, inject } from '@angular/core/testing';

import { ActivosService } from './activos.service';

describe('ActivosService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ActivosService]
    });
  });

  it('should be created', inject([ActivosService], (service: ActivosService) => {
    expect(service).toBeTruthy();
  }));
});
