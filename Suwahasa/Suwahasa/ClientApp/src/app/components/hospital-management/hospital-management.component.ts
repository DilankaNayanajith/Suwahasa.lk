import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { HospitalStates } from '../../models/enums';
import { Hospital } from '../../models/hospital-model';
import { HospitalsService } from '../../services/hospitals.service';
import { AddOrEditHospitalComponent } from './add-or-edit-hospital/add-or-edit-hospital.component';

@Component({
  selector: 'app-hospital-management',
  templateUrl: './hospital-management.component.html',
  styleUrls: ['./hospital-management.component.scss']
})
export class HospitalManagementComponent implements OnInit {
  public displayedColumns: string[] = ['name', 'category', 'sub-category', 'city', 'actions'];
  public hospitals: Hospital[] = [];

  @ViewChild(MatSort) sort: MatSort = new MatSort();
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private hospitalsService: HospitalsService,
    public dialog: MatDialog) { }

  public hospitalsDataSource = new MatTableDataSource(this.hospitals);

  ngOnInit(): void {
    this.getAllHospitals();
  }

  private getAllHospitals() {
    this.hospitalsService.getAllHospitals()
      .subscribe(data => {
        if (data) {
          this.hospitals = data;
          this.hospitalsDataSource = new MatTableDataSource(this.hospitals);
        }
      }, err => {
        console.error('AddEmployeeComponent: getAllHospitals: ', err);
      })
  }

  public openAddHospitalDialog(){
    let dialogRef = this.dialog.open(AddOrEditHospitalComponent, {
      width: '800px',
      data: {
        state: HospitalStates.New,
        hospital: null,
        hospitals: this.hospitals
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result){
        this.getAllHospitals();
      }
    });
  }

  public openEditHospitalDialog(hospital: Hospital){
    let dialogRef = this.dialog.open(AddOrEditHospitalComponent, {
      width: '800px',
      data: {
        state: HospitalStates.Existing,
        hospital: hospital,
        hospitals: this.hospitals
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result){
        this.getAllHospitals();
      }
    });
  }

  public deleteHospital(hospital: Hospital){
    this.hospitalsService.deleteHospital(hospital.id)
    .subscribe(res => {
      this.getAllHospitals();
    }, err=> {
      console.error('AddEmployeeComponent: deleteHospital: ', err);
    })
  }
}
