import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Validations } from 'src/app/common/functions';
import { District, districts } from 'src/app/models/common-data';
import { Employee } from 'src/app/models/employee-model';
import { EmployeeStates } from 'src/app/models/enums';
import { Hospital } from 'src/app/models/hospital-model';
import { PropertyValidationModel } from 'src/app/models/property-validation-model';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-add-or-edit-employee',
  templateUrl: './add-or-edit-employee.component.html',
  styleUrls: ['./add-or-edit-employee.component.scss']
})
export class AddOrEditEmployeeComponent implements OnInit {

  public hospitals: Hospital[] = [];
  public roles: string[] = ['Doctor', 'Nurse', 'Driver', 'Admin'];
  public employeeStatusList: string[] = ['Active', 'Inactive'];
  public employee: Employee = new Employee();
  public state: string = 'new';
  public disableHospital: boolean = false;
  public districts: District[] = districts;
  public isValid: boolean = true;
  public invalidText: string = '';

  constructor(
    public dialog: MatDialog,
    public dialogRef: MatDialogRef<AddOrEditEmployeeComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private employeesService: EmployeesService)
  {
    this.hospitals = data.hospitals;
    this.state = data.state;
    if (this.state == EmployeeStates.New){
      this.employee = new Employee();
      this.employee.hospitalFk = this.hospitals[0].id;
      this.employee.role = this.roles[0];
      this.employee.active = true;
      this.employee.district = districts[0].name;
      this.employee.province = districts[0].province;
    } else if (this.state == EmployeeStates.ManageNew) {
      this.employee = new Employee();
      this.employee.hospitalFk = this.hospitals[0].id;
      this.employee.role = this.roles[0];
      this.employee.active = true;
      this.disableHospital = true;
      this.employee.district = districts[0].name;
      this.employee.province = districts[0].province;
    } else if (this.state == EmployeeStates.Manage){
      this.employee = data.employee;
      this.disableHospital = true;
    } else{
      this.employee = data.employee;
    }
  }

  ngOnInit(): void {

  }

  public validateEmployeeData():boolean{
    let status: boolean = true;
    let invalidFields: string[] = [];
    if (!Validations.validateString(this.employee.firstName!)){
      invalidFields.push("First Name");
      status = false;
    }

    if (!Validations.validateString(this.employee.lastName!)){
      invalidFields.push("Last Name");
      status = false;
    }

    if (!Validations.validateNationalId(this.employee.nic!)){
      invalidFields.push("National Id");
      status = false;
    }

    if (!Validations.validateContact(this.employee.phone!)){
      invalidFields.push("Contact Number");
      status = false;
    }

    if (!Validations.validateEmail(this.employee.email!)){
      invalidFields.push("Email");
      status = false;
    }

    if (!Validations.validateString(this.employee.addressLine1!)){
      invalidFields.push("Address Line 1");
      status = false;
    }

    if (!Validations.validateString(this.employee.city!)){
      invalidFields.push("City");
      status = false;
    }

    if (!Validations.validateString(this.employee.district!)){
      invalidFields.push("District");
      status = false;
    }

    if (!Validations.validateString(this.employee.province!)){
      invalidFields.push("Province");
      status = false;
    }

    if (!Validations.validateString(this.employee.role!)){
      invalidFields.push("Role");
      status = false;
    }

    if (!(Validations.isOnlyNumbers(this.employee.hospitalFk.toString()) && Number(this.employee.hospitalFk) > 0)){
      invalidFields.push("Hospital");
      status = false;
    }

    // this.invalidText = '';
    // for (let i=0; i < this.invalidFields.length; i++){
    //   if (i == this.invalidFields.length - 1){
    //     this.invalidText += `${this.invalidFields[i]} `;
    //   }else{
    //     this.invalidText += `${this.invalidFields[i]}, `;
    //   }
    // }
    // this.invalidText += 'fields are invalid, please enter valid details and try again.'
    this.invalidText = '';
    this.invalidText = Validations.generateInvalidText(invalidFields);

    return status;
  }

  public createEmployee() {
    if (this.validateEmployeeData()) {
      console.log('AddEmployeeComponent: createEmployee: ', this.employee);
      this.employeesService.createEmployee(this.employee)
        .subscribe(res => {
          this.dialogRef.close(true);
        }, err => {
          if (err) {
            console.error('AddEmployeeComponent: createEmployee: ', err);
          }
        });
        this.isValid = true;
    }else{
      this.isValid = false;
    }
  }

  onDistrictChange(event?:any){
    let selectedDistrict = event.target.value;
    let index = districts.findIndex(d => d.name == selectedDistrict);
    this.employee.district = districts[index].name;
    this.employee.province = districts[index].province;
  }

  public onRoleChange(event?:any){
    this.employee.role = event.target.value;
  }

  public onHospitalChange(event?:any){
    this.employee.hospitalFk = event.target.value;
  }

  public onStatusChange(event?:any){
    this.employee.active = event.target.value == 'Active';
  }

  public closeDialog(){
    this.dialogRef.close(false);
  }

}
