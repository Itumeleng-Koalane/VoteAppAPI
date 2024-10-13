import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProvincialPartiesComponent } from './provincial-parties.component';

describe('ProvincialPartiesComponent', () => {
  let component: ProvincialPartiesComponent;
  let fixture: ComponentFixture<ProvincialPartiesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProvincialPartiesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProvincialPartiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
