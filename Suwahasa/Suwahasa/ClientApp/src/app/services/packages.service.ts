import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Package } from '../models/package-model';
import { Inject } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PackagesService {
  private api = environment.baseUrl;
  private baseUrl = `${this.api}/api/Packages`;

  constructor(private httpClient: HttpClient) { }

  public upsertPackage(data: Package)
  {
    return this.httpClient.post<any>(this.baseUrl, data);
  }

  public deletePackage(packageId: number)
  {
    let url = `${this.baseUrl}/${packageId}`;
    return this.httpClient.delete<any>(url);
  }
}
