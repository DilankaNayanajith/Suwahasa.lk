import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { Hospital } from 'src/app/models/hospital-model';
import { Package } from 'src/app/models/package-model';
import { HospitalsService } from 'src/app/services/hospitals.service';
import { MakeReservationComponent } from '../../reservation-management/make-reservation/make-reservation.component';

@Component({
  selector: 'app-hospital-info',
  templateUrl: './hospital-info.component.html',
  styleUrls: ['./hospital-info.component.scss']
})
export class HospitalInfoComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    public dialog: MatDialog,
    private hospitalsService: HospitalsService) { }

  public hospitalId: number = 0;
  public hospital: Hospital = new Hospital();
  public packagesDataSource = new MatTableDataSource(this.hospital.packages);
  public veiclesDataSource = new MatTableDataSource(this.hospital.vehicles);
  public employeesDataSource = new MatTableDataSource(this.hospital.employees);

  public packageDisplayedColumns: string[] = ['name', 'price', 'actions'];

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.hospitalId = Number(params.get('id'));
      this.getHospital(this.hospitalId);
    })
  }

  private getHospital(hospitalId: number) {
    this.hospitalsService.getHospitalById(hospitalId)
      .subscribe(res => {
        this.hospital = res;
        this.packagesDataSource = new MatTableDataSource(this.hospital.packages);
        this.veiclesDataSource = new MatTableDataSource(this.hospital.vehicles);
        this.employeesDataSource = new MatTableDataSource(this.hospital.employees);
        console.log('hospital: ', this.hospital);
      }, err => {
        console.error('ManageHospitalComponent: getHospital: ', err);
      });
  }

  public openMakeReservationDialog(pkg: Package) {
    console.log('openMakeReservationDialog: ', pkg);
    let dialogRef = this.dialog.open(MakeReservationComponent, {
      width: '800px',
      data: {
        package: pkg,
        hospital: this.hospital
      }
    });
  }

}
