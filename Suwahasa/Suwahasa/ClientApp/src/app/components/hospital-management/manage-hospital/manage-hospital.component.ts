import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import {MatPaginator} from '@angular/material/paginator';
import { Router, ActivatedRoute } from '@angular/router';
import { EmployeeStates, PackageStates, VehicleStates } from 'src/app/models/enums';
import { Hospital } from 'src/app/models/hospital-model';
import { Package } from 'src/app/models/package-model';
import { HospitalsService } from 'src/app/services/hospitals.service';
import { PackagesService } from 'src/app/services/packages.service';
import { AddOrEditPackageComponent } from '../add-or-edit-package/add-or-edit-package.component';
import { Vehicle } from 'src/app/models/vehicle-model';
import { AddOrEditVehicleComponent } from '../../vehicle-management/add-or-edit-vehicle/add-or-edit-vehicle.component';
import { AddOrEditEmployeeComponent } from '../../employee-management/add-or-edit-employee/add-or-edit-employee.component';
import { Employee } from 'src/app/models/employee-model';
import { EmployeesService } from 'src/app/services/employees.service';
import { VehiclesService } from 'src/app/services/vehicles.service';

@Component({
  selector: 'app-manage-hospital',
  templateUrl: './manage-hospital.component.html',
  styleUrls: ['./manage-hospital.component.scss']
})
export class ManageHospitalComponent implements OnInit {
  public hospitalId: number = 0;
  public hospital: Hospital = new Hospital();
  public packagesDataSource = new MatTableDataSource(this.hospital.packages);
  public veiclesDataSource = new MatTableDataSource(this.hospital.vehicles);
  public employeesDataSource = new MatTableDataSource(this.hospital.employees);

  public packageDisplayedColumns: string[] = ['name', 'price', 'actions'];
  public vehicleDisplayedColumn: string[] = ['category', 'vehicle-number', 'driver', 'actions'];
  public employeesDisplayedColumns: string[] = ['name', 'hospital', 'role', 'active', 'contact', 'actions'];

  //@ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(
    private router: ActivatedRoute,
    private routers: Router,
    public dialog: MatDialog,
    private hospitalsService: HospitalsService,
    private packagesService: PackagesService,
    private employeesService: EmployeesService,
    private vehiclesService: VehiclesService) { }

  ngOnInit(): void {
    this.getHospitalId();
  }

  ngAfterViewInit() {
    //this.packagesDataSource.paginator = this.paginator;
  }

  private getHospitalId() {
    this.router.params.subscribe(params => {
      this.hospitalId = params['hospitalId'];
      this.getHospital(this.hospitalId);
    });
  }

  private getHospital(hospitalId: number){
    this.hospitalsService.getHospitalById(hospitalId)
      .subscribe(res => {
        this.hospital = res;
        this.packagesDataSource = new MatTableDataSource(this.hospital.packages);
        this.veiclesDataSource = new MatTableDataSource(this.hospital.vehicles);
        this.employeesDataSource = new MatTableDataSource(this.hospital.employees);
      }, err => {
        console.error('ManageHospitalComponent: getHospital: ', err);
      })
  }

  //Packages
  public openAddPackageDialog()
  {
    let dialogRef = this.dialog.open(AddOrEditPackageComponent, {
      width: '800px',
      data: {
        state: PackageStates.New,
        package: null,
        hospital: this.hospital
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result){
        this.getHospital(this.hospitalId);
      }
    });
  }

  public openEditPackageDialog(element: Package){
    let dialogRef = this.dialog.open(AddOrEditPackageComponent, {
      width: '800px',
      data: {
        state: PackageStates.Existing,
        package: element,
        hospital: this.hospital
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result){
        this.getHospital(this.hospitalId);
      }
    });
  }

  public deletePackage(element: Package){
    this.packagesService.deletePackage(element.id)
      .subscribe(res => {
        this.getHospital(this.hospitalId);
      }, err => {
        console.error('ManageHospitalComponent: deletePackage: ', err);
      })
  }

  //Vehicles

  public openAddVehicleDialog(){
    let dialogRef = this.dialog.open(AddOrEditVehicleComponent, {
      width: '800px',
      data: {
        state: VehicleStates.ManageNew,
        vehicle: null,
        hospitals: [this.hospital]
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result){
        this.getHospital(this.hospitalId);
      }
    });
  }

  public openEditVehicleDialog(element: Vehicle)
  {
    let dialogRef = this.dialog.open(AddOrEditVehicleComponent, {
      width: '800px',
      data: {
        state: VehicleStates.Manage,
        vehicle: element,
        hospitals: [this.hospital]
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result){
        this.getHospital(this.hospitalId);
      }
    });
  }

  public deleteVehicle(element: Vehicle)
  {
    this.vehiclesService.deleteVehicle(element.id)
      .subscribe(res => {
        this.getHospital(this.hospitalId);
      }, err => {
        console.error('ManageHospitalComponent: deleteVehicle: ', err);
      })
  }

  //Employees////////////////////////////////////////////////////////////////////////////////
  public openAddEmployeeDialog(){
    let dialogRef = this.dialog.open(AddOrEditEmployeeComponent, {
      width: '800px',
      data: {
        state: EmployeeStates.ManageNew,
        employee: null,
        hospitals: [this.hospital]
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result){
        this.getHospital(this.hospitalId);
      }
    });
  }

  public openEditEmployeeDialog(employee: Employee){
    if (employee){
      let doalogRef = this.dialog.open(AddOrEditEmployeeComponent, {
        width: '800px',
        data: {
          state: EmployeeStates.Manage,
          employee,
          hospitals: [this.hospital]
        }
      });

      doalogRef.afterClosed().subscribe(result => {
        if (result){
          this.getHospital(this.hospitalId);
        }
      });
    }
  }

  public deleteEmployee(employee: Employee){
    if (employee){
      this.employeesService.deleteEmployee(employee.id)
        .subscribe(res => {
          this.getHospital(this.hospitalId);
        }, err => {
          console.error('ManageHospitalComponent: deleteEmployee: ', err);
        });

    }
  }
}
