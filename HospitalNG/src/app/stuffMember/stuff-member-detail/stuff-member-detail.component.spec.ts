import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StuffMemberDetailComponent } from './stuff-member-detail.component';

describe('StuffMemberDetailComponent', () => {
  let component: StuffMemberDetailComponent;
  let fixture: ComponentFixture<StuffMemberDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StuffMemberDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StuffMemberDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
