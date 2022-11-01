import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewStuffMemberComponent } from './new-stuff-member.component';

describe('NewStuffMemberComponent', () => {
  let component: NewStuffMemberComponent;
  let fixture: ComponentFixture<NewStuffMemberComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewStuffMemberComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewStuffMemberComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
