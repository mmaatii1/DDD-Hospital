import { TestBed } from '@angular/core/testing';

import { TypeOfStuffMemberService } from './type-of-stuff-member.service';

describe('TypeOfStuffMemberService', () => {
  let service: TypeOfStuffMemberService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TypeOfStuffMemberService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
