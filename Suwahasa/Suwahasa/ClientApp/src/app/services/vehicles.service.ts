import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Vehicle } from '../models/vehicle-model';
import { Inject } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class VehiclesService {
  private api = environment.baseUrl;
  private baseUrl = `${this.api}/api/Vehicles`;

  constructor(private httpClient: HttpClient) { }

  public getAllVehicles(){
    return this.httpClient.get<any>(this.baseUrl);
  }

  public upsertVehicle(data: Vehicle){
    return this.httpClient.post<any>(this.baseUrl, data);
  }

  public deleteVehicle(vehicleId: number){
    let url = `${this.baseUrl}/${vehicleId}`;
    return this.httpClient.delete<any>(url);
  }
}
