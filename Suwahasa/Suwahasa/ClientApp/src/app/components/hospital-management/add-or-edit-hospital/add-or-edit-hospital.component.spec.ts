import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddOrEditHospitalComponent } from './add-or-edit-hospital.component';

describe('AddOrEditHospitalComponent', () => {
  let component: AddOrEditHospitalComponent;
  let fixture: ComponentFixture<AddOrEditHospitalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddOrEditHospitalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddOrEditHospitalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
