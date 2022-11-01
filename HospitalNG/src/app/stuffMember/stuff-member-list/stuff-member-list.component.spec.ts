import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StuffMemberListComponent } from './stuff-member-list.component';

describe('StuffMemberListComponent', () => {
  let component: StuffMemberListComponent;
  let fixture: ComponentFixture<StuffMemberListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StuffMemberListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StuffMemberListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
