import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Hospital } from '../models/hospital-model';
import { Inject } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HospitalsService {
  private api = environment.baseUrl;
  private baseUrl = `${this.api}/api/Hospitals`;

  constructor(private httpClient: HttpClient) { }

  public getAllHospitals(){
    return this.httpClient.get<any>(this.baseUrl);
  }

  public getHospitalById(hospitalId: number){
    let url = `${this.baseUrl}/${hospitalId}`;
    return this.httpClient.get<any>(url);
  }

  public getHospitalByCity(city: string) {
    let url = `${this.baseUrl}/search?city=${city}`;
    return this.httpClient.get<any>(url);
  }

  public upsertHospital(data: Hospital){
    return this.httpClient.post<any>(this.baseUrl, data);
  }

  public deleteHospital(hospitalId: number){
    let url = `${this.baseUrl}/${hospitalId}`;
    return this.httpClient.delete<any>(url);
  }
}
