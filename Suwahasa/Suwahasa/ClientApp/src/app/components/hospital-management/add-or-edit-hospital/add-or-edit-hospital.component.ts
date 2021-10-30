import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Validations } from 'src/app/common/functions';
import { District, districts } from 'src/app/models/common-data';
import { HospitalStates } from 'src/app/models/enums';
import { Hospital } from 'src/app/models/hospital-model';
import { HospitalsService } from 'src/app/services/hospitals.service';

@Component({
  selector: "app-add-or-edit-hospital",
  templateUrl: "./add-or-edit-hospital.component.html",
  styleUrls: ["./add-or-edit-hospital.component.scss"],
})
export class AddOrEditHospitalComponent implements OnInit {
  public hospital: Hospital = new Hospital();
  public categories: string[] = ["Public", "Private"];
  public subCategories: string[] = ["Hospital", "Hotel", "Quarantine center"];
  public state: string = HospitalStates.New;
  public districts: District[] = districts;
  public isValid: boolean = true;
  public invalidText: string = "";

  constructor(
    public dialog: MatDialog,
    public dialogRef: MatDialogRef<AddOrEditHospitalComponent>,
    public hospitalsService: HospitalsService,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.state = data.state;
    if (this.state == HospitalStates.New) {
      this.hospital = new Hospital();
      this.hospital.category = this.categories[0];
      this.hospital.subcategory = this.subCategories[0];
      this.hospital.district = districts[0].name;
      this.hospital.province = districts[0].province;
    } else {
      this.hospital = data.hospital;
    }
  }

  ngOnInit(): void {}

  public validateHospitalData(): boolean {
    let status: boolean = true;
    let invalidFields: string[] = [];

    if (!Validations.validateString(this.hospital.name!)) {
      invalidFields.push("Name");
      status = false;
    }

    if (!Validations.validateContact(this.hospital.phone!)) {
      invalidFields.push("Contact");
      status = false;
    }

    if (!Validations.validateString(this.hospital.category!)) {
      invalidFields.push("Category");
      status = false;
    }

    if (!Validations.validateString(this.hospital.subcategory!)) {
      invalidFields.push("Sub Category");
      status = false;
    }

    if (!Validations.validateString(this.hospital.addressLine1!)) {
      invalidFields.push("Address Line 1");
      status = false;
    }

    if (!Validations.validateString(this.hospital.city!)) {
      invalidFields.push("City");
      status = false;
    }

    if (!Validations.validateString(this.hospital.district!)) {
      invalidFields.push("District");
      status = false;
    }

    if (!Validations.validateString(this.hospital.province!)) {
      invalidFields.push("Province");
      status = false;
    }

    this.invalidText = "";
    this.invalidText = Validations.generateInvalidText(invalidFields);

    return status;
  }

  public createHospital() {
    if (this.validateHospitalData()) {
      this.hospitalsService.upsertHospital(this.hospital).subscribe(
        (res) => {
          this.dialogRef.close(true);
        },
        (err) => {
          console.error("AddOrEditHospitalComponent: createHospital: ", err);
        }
      );
      this.isValid = true;
    } else this.isValid = false;
  }

  onDistrictChange(event: any) {
    let selectedDistrict = event.target.value;
    let index = districts.findIndex((d) => d.name == selectedDistrict);
    this.hospital.district = districts[index].name;
    this.hospital.province = districts[index].province;
  }

  public closeDialog() {
    this.dialogRef.close();
  }

  public onCategoryChange(event: any) {
    console.log("onCategoryChange: ", event.target.value);
    this.hospital.category = event.target.value;
  }

  public onSubcategoryChange(event: any) {
    console.log("onSubcategoryChange: ", event.target.value);
    this.hospital.subcategory = event.target.value;
  }
}
