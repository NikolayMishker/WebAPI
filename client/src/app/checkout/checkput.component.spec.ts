import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CheckputComponent } from './checkput.component';

describe('CheckputComponent', () => {
  let component: CheckputComponent;
  let fixture: ComponentFixture<CheckputComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CheckputComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CheckputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
