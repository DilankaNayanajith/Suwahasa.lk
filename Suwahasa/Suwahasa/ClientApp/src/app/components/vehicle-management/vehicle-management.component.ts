import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Employee } from 'src/app/models/employee-model';
import { VehicleStates } from 'src/app/models/enums';
import { Hospital } from 'src/app/models/hospital-model';
import { EmployeesService } from 'src/app/services/employees.service';
import { Vehicle } from '../../models/vehicle-model';
import { HospitalsService } from '../../services/hospitals.service';
import { VehiclesService } from '../../services/vehicles.service';
import { AddOrEditVehicleComponent } from './add-or-edit-vehicle/add-or-edit-vehicle.component';

@Component({
  selector: 'app-vehicle-management',
  templateUrl: './vehicle-management.component.html',
  styleUrls: ['./vehicle-management.component.scss']
})
export class VehicleManagementComponent implements OnInit {
  public vehicles:Vehicle[] = [];
  public hospitals: Hospital[] = [];
  public drivers: Employee[] = [];
  public displayedColumns: string[] = ['category', 'driver', 'vehicle-number', 'type', 'facility', 'actions'];

  @ViewChild(MatSort) sort: MatSort = new MatSort();
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private hospitalsService: HospitalsService,
    private vehiclesService: VehiclesService,
    private employeesService: EmployeesService,
    public dialog: MatDialog
  ) { }

  public vehiclesDataSource = new MatTableDataSource(this.vehicles);

  ngOnInit(): void {
    this.getAllVehicles();
    this.getAllHospitals();
  }

  private getAllVehicles() {
    this.vehiclesService.getAllVehicles()
      .subscribe(data => {
        if (data) {
          this.vehicles = data;
          this.vehiclesDataSource = new MatTableDataSource(this.vehicles);
        }
      }, err => {
        console.error('VehicleManagementComponent: getAllVehicles: ', err);
      })
  }

  private getAllHospitals(){
    this.hospitalsService.getAllHospitals()
    .subscribe(res => {
      this.hospitals = res;
    }, err => {
      console.error('AddOrEditVehicleComponent: getAllHospitals: ', err);
    })
  }

  public openAddVehicleDialog()
  {
    let dialogRef = this.dialog.open(AddOrEditVehicleComponent, {
      width: '800px',
      data: {
        state: VehicleStates.New,
        vehicle: null,
        hospitals: this.hospitals,
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result){
        this.getAllVehicles();
      }
    });
  }

  public openEditVehicleDialog(vehicle: Vehicle)
  {
    let dialogRef = this.dialog.open(AddOrEditVehicleComponent, {
      width: '800px',
      data: {
        state: VehicleStates.Existing,
        vehicle: vehicle,
        hospitals: this.hospitals,
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result){
        this.getAllVehicles();
      }
    });
  }

  public deleteVehicle(vehicle: Vehicle)
  {

  }
}
