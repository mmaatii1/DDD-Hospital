import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TypeOfStuffMemberDetailComponent } from './type-of-stuff-member-detail.component';

describe('TypeOfStuffMemberDetailComponent', () => {
  let component: TypeOfStuffMemberDetailComponent;
  let fixture: ComponentFixture<TypeOfStuffMemberDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TypeOfStuffMemberDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TypeOfStuffMemberDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
