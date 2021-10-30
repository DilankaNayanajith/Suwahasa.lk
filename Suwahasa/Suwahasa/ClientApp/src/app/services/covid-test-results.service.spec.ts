import { TestBed } from '@angular/core/testing';

import { CovidTestResultsService } from './covid-test-results.service';

describe('CovidTestResultsService', () => {
  let service: CovidTestResultsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CovidTestResultsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
