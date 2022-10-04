import { TestBed } from '@angular/core/testing';

import { PatientEditGuard } from './patient-edit.guard';

describe('PatientEditGuard', () => {
  let guard: PatientEditGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(PatientEditGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
