import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Validations } from 'src/app/common/functions';
import { Employee } from 'src/app/models/employee-model';
import { VehicleStates } from 'src/app/models/enums';
import { Hospital } from 'src/app/models/hospital-model';
import { Vehicle } from 'src/app/models/vehicle-model';
import { EmployeesService } from 'src/app/services/employees.service';
import { HospitalsService } from 'src/app/services/hospitals.service';
import { VehiclesService } from 'src/app/services/vehicles.service';

@Component({
  selector: "app-add-or-edit-vehicle",
  templateUrl: "./add-or-edit-vehicle.component.html",
  styleUrls: ["./add-or-edit-vehicle.component.scss"],
})
export class AddOrEditVehicleComponent implements OnInit {
  public vehicle: Vehicle = new Vehicle();
  public categories: string[] = ["Ambulance", "Other"];
  public types: string[] = ["Van", "Bus", "Cab", "SUV"];
  public statusList: string[] = ["Available", "Unavailable"];
  public hospitals: Hospital[] = [];
  public drivers: Employee[] = [];
  public state: string = "new";
  public disabledHospital: boolean = false;
  public isValid: boolean = true;
  public invalidText: string = "";

  constructor(
    public dialog: MatDialog,
    public dialogRef: MatDialogRef<AddOrEditVehicleComponent>,
    private hospitalsService: HospitalsService,
    private employeesService: EmployeesService,
    private vehiclesService: VehiclesService,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.state = data.state;
    this.hospitals = data.hospitals;

    if (this.state == VehicleStates.New) {
      this.vehicle = new Vehicle();
      this.vehicle.category = this.categories[0];
      this.vehicle.type = this.types[0];
      this.vehicle.available = true;
      this.vehicle.availableText = this.statusList[0];
      if (this.hospitals.length > 0) {
        this.vehicle.hospitalFk = this.hospitals[0].id;
        this.getDrivers(this.hospitals[0].id);
      }
    } else if (this.state == VehicleStates.ManageNew) {
      this.vehicle = new Vehicle();
      this.vehicle.category = this.categories[0];
      this.vehicle.type = this.types[0];
      this.vehicle.available = false;
      this.vehicle.availableText = this.statusList[0];
      this.vehicle.hospitalFk = this.hospitals[0].id;
      this.getDrivers(this.hospitals[0].id);
      this.disabledHospital = true;
    } else if (this.state == VehicleStates.Manage) {
      this.vehicle = data.vehicle;
      this.getDrivers(this.hospitals[0].id);
      this.disabledHospital = true;
    } else {
      this.vehicle = data.vehicle;
      this.getDrivers(data.vehicle.hospital.id);
    }
  }

  ngOnInit(): void {}

  private getDrivers(hospitalId: number) {
    this.employeesService.searchEmployees(hospitalId, "Driver").subscribe(
      (res) => {
        this.drivers = res;
        if (this.vehicle.driverFk == 0 && this.drivers.length > 0) {
          this.vehicle.driverFk = this.drivers[0].id;
        }
      },
      (err) => {
        console.error("AddOrEditVehicleComponent: getDrivers: ", err);
      }
    );
  }

  public onCategoryChange(event: any) {
    this.vehicle.category = event.target.value;
  }

  public onTypeChange(event: any) {
    this.vehicle.type = event.target.value;
  }

  public onStatusChange(event: any) {
    let value = event.target.value;
    if (value == this.statusList[0]) {
      this.vehicle.available = true;
      this.vehicle.availableText = value;
    } else {
      this.vehicle.available = false;
      this.vehicle.availableText = this.statusList[1];
    }
  }

  public onHospitalChange(event: any) {
    this.vehicle.hospitalFk = event.target.value;
    this.vehicle.driverFk = 0;
    this.getDrivers(this.vehicle.hospitalFk);
  }

  public onDriverChange(event: any) {
    this.vehicle.driverFk = event.target.value;
  }

  public validateVehicleData(): boolean {
    let status: boolean = true;
    let invalidFields: string[] = [];

    if (!Validations.validateString(this.vehicle.make)) {
      invalidFields.push("Make");
    }

    if (!Validations.validateString(this.vehicle.model)) {
      invalidFields.push("Model");
    }

    if (!Validations.validateVehicleNumber(this.vehicle.vehicleNumber)) {
      invalidFields.push("Vehicle Number");
    }

    if (!(this.vehicle.hospitalFk > 0)) {
      invalidFields.push("Hospital");
    }

    if (!(this.vehicle.driverFk > 0)) {
      invalidFields.push("Driver");
    }

    console.log(this.vehicle);

    this.invalidText = Validations.generateInvalidText(invalidFields);

    return !(invalidFields.length > 0);
  }

  public createVehicle() {
    if (this.validateVehicleData()) {
      this.vehiclesService.upsertVehicle(this.vehicle).subscribe(
        (res) => {
          this.dialogRef.close(true);
        },
        (err) => {
          console.log("AddOrEditVehicleComponent: createVehicle: ", err);
        }
      );
      this.isValid = true;
    } else {
      this.isValid = false;
    }
  }

  public closeDialog() {
    this.dialogRef.close();
  }
}
