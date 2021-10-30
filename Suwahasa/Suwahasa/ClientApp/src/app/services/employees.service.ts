import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Employee } from '../models/employee-model';
import { Inject } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {
  private api = environment.baseUrl;
  private baseUrl = `${this.api}/api/Employees`;

  constructor(private httpClient: HttpClient) { }

  public getAllEmployees(){
    let url = this.baseUrl;
    return this.httpClient.get<any>(url);
  }

  public searchEmployees(hospitalId: number, role: string){
    let url = `${this.baseUrl}/search?hospitalId=${hospitalId}&role=${role}`;
    return this.httpClient.get<any>(url);
  }

  public createEmployee(data: Employee){
    let url = this.baseUrl;
    return this.httpClient.post<any>(url, data);
  }

  public deleteEmployee(employeeId: number){
    let url = `${this.baseUrl}/${employeeId}`;
    return this.httpClient.delete<any>(url);
  }

  public createUserForEmployee(employeeId: number){
    let url = `${this.baseUrl}/user?employeeId=${employeeId}`;
    return this.httpClient.post<any>(url, {});
  }

  public resetUserForEmployee(employeeId: number){
    let url = `${this.baseUrl}/user/reset?employeeId=${employeeId}`;
    return this.httpClient.post<any>(url, {});
  }
}
