import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { EmployeesService } from '../../services/employees.service';
import { MatTableDataSource } from '@angular/material/table';
import { Employee } from '../../models/employee-model';
import {MatSort} from '@angular/material/sort';
import {MatPaginator} from '@angular/material/paginator';
import {MatDialog} from '@angular/material/dialog';
import { AddOrEditEmployeeComponent } from './add-or-edit-employee/add-or-edit-employee.component';
import { EmployeeStates } from '../../models/enums';
import { Hospital } from '../../models/hospital-model';
import { HospitalsService } from '../../services/hospitals.service';

@Component({
  selector: 'app-employee-management',
  templateUrl: './employee-management.component.html',
  styleUrls: ['./employee-management.component.scss']
})
export class EmployeeManagementComponent implements OnInit, AfterViewInit {

  public employees: Employee[] = [];
  public hospitals: Hospital[] = [];
  public displayedColumns: string[] = ['name', 'hospital', 'role', 'active', 'contact', 'actions'];

  @ViewChild(MatSort) sort: MatSort = new MatSort();
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private employeesService: EmployeesService,
    private hospitalsService: HospitalsService,
    public dialog: MatDialog) { }

  public employeesDataSource = new MatTableDataSource(this.employees);

  ngOnInit(): void {
    this.getAllEmployees();
    this.getAllHospitals();
  }

  ngAfterViewInit() {
    this.getAllEmployees();
    this.employeesDataSource.sort = this.sort;
    this.employeesDataSource.paginator = this.paginator;
  }

  private getAllEmployees(){
    this.employeesService.getAllEmployees()
      .subscribe(data => {
        if (data) {
          this.employees = data;
          this.employeesDataSource = new MatTableDataSource(this.employees);
        }
      }, err => {
        console.error('EmployeeManagementComponent: ngOnInit: ', err);
      });
  }

  private getAllHospitals() {
    this.hospitalsService.getAllHospitals()
      .subscribe(data => {
        if (data) {
          this.hospitals = data;
        }
      }, err => {
        console.error('AddEmployeeComponent: getAllHospitals: ', err);
      })
  }

  public openAddEmployeeDialog(){
    let dialogRef = this.dialog.open(AddOrEditEmployeeComponent, {
      width: '700px',
      height: '650px',
      data: {
        state: EmployeeStates.New,
        employee: null,
        hospitals: this.hospitals
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result){
        this.getAllEmployees();
      }
    });
  }

  public openEditEmployeeDialog(employee: Employee){
    if (employee){
      let doalogRef = this.dialog.open(AddOrEditEmployeeComponent, {
        width: '600px',
        data: {
          state: EmployeeStates.Existing,
          employee,
          hospitals: this.hospitals
        }
      });

      doalogRef.afterClosed().subscribe(result => {
        if (result){
          this.getAllEmployees();
        }
      });
    }
  }

  public deleteEmployee(employee: Employee){
    if (employee){
      this.employeesService.deleteEmployee(employee.id)
        .subscribe(res => {
          this.getAllEmployees();
        }, err => {
          console.error('EmployeeManagementComponent: deleteEmployee: ', err);
        });

    }
  }

  public createUserForEmployee(employee: Employee){
    if (employee){
      this.employeesService.createUserForEmployee(employee.id)
        .subscribe(res => {
          this.getAllEmployees();
        }, err => {
          console.error('EmployeeManagementComponent: createUserForEmployee: ', employee);
        })
    }
  }

  public resetUserForEmployee(employee: Employee){
    if (employee){
      this.employeesService.resetUserForEmployee(employee.id)
        .subscribe(res => {
          this.getAllEmployees();
        }, err => {
          console.error('EmployeeManagementComponent: createUserForEmployee: ', employee);
        })
    }
  }
}
