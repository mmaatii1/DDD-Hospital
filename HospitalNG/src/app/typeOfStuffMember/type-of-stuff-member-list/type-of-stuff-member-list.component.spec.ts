import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TypeOfStuffMemberListComponent } from './type-of-stuff-member-list.component';

describe('TypeOfStuffMemberListComponent', () => {
  let component: TypeOfStuffMemberListComponent;
  let fixture: ComponentFixture<TypeOfStuffMemberListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TypeOfStuffMemberListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TypeOfStuffMemberListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
