import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProvincialSelectionScreenComponent } from './provincial-selection-screen.component';

describe('ProvincialSelectionScreenComponent', () => {
  let component: ProvincialSelectionScreenComponent;
  let fixture: ComponentFixture<ProvincialSelectionScreenComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProvincialSelectionScreenComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProvincialSelectionScreenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
