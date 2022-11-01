import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewTypeOfStuffMemberComponent } from './new-type-of-stuff-member.component';

describe('NewTypeOfStuffMemberComponent', () => {
  let component: NewTypeOfStuffMemberComponent;
  let fixture: ComponentFixture<NewTypeOfStuffMemberComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewTypeOfStuffMemberComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewTypeOfStuffMemberComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
