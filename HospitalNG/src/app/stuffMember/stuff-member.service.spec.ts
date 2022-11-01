import { TestBed } from '@angular/core/testing';

import { StuffMemberService } from './stuff-member.service';

describe('StuffMemberService', () => {
  let service: StuffMemberService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StuffMemberService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
