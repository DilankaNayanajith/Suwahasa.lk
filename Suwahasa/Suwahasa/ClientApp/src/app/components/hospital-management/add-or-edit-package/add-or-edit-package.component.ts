import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { PackageStates } from 'src/app/models/enums';
import { Hospital } from 'src/app/models/hospital-model';
import { Package } from 'src/app/models/package-model';
import { HospitalsService } from 'src/app/services/hospitals.service';
import { PackagesService } from 'src/app/services/packages.service';
import { AddOrEditHospitalComponent } from '../add-or-edit-hospital/add-or-edit-hospital.component';

@Component({
  selector: 'app-add-or-edit-package',
  templateUrl: './add-or-edit-package.component.html',
  styleUrls: ['./add-or-edit-package.component.scss']
})
export class AddOrEditPackageComponent implements OnInit {
  public package: Package = new Package();
  public hospital: Hospital = new Hospital();
  public state: string = 'new';

  constructor(
    public dialog: MatDialog,
    public dialogRef: MatDialogRef<AddOrEditPackageComponent>,
    public hospitalsService: HospitalsService,
    public packagesService: PackagesService,
    @Inject(MAT_DIALOG_DATA) public data: any
  )
  {
    this.state = data.state;
    this.hospital = data.hospital;
    if (this.state == PackageStates.New){
      this.package = new Package();
      this.package.hospitalFk = this.hospital.id;
    }else{
      this.package = data.package;
    }
  }

  ngOnInit(): void {
  }

  public upsertPackage()
  {
    this.packagesService.upsertPackage(this.package)
      .subscribe(ref => {
        this.dialogRef.close(true);
      }, err => {
        console.error('AddOrEditPackageComponent: createPackage: ', err);
      })
  }

  public closeDialog()
  {
    this.dialogRef.close(false);
  }

}
