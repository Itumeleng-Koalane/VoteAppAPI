import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NationalPartiesComponent } from './national-parties.component';

describe('NationalPartiesComponent', () => {
  let component: NationalPartiesComponent;
  let fixture: ComponentFixture<NationalPartiesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NationalPartiesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NationalPartiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
