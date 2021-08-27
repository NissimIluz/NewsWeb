import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PreReviewComponent } from './pre-review.component';

describe('PreReviewComponent', () => {
  let component: PreReviewComponent;
  let fixture: ComponentFixture<PreReviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PreReviewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PreReviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
