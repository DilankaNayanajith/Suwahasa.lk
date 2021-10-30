import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Inject } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private api = environment.baseUrl;
  private baseUrl = `${this.api}/api/Auth`;
  //private baseUrl = `https://localhost:44334/api/Auth`;

  constructor(private httpClient: HttpClient) {}

  public register(data: any){
    let url = `${this.baseUrl}/register`;
    return this.httpClient.post<any>(url, data);
  }

  public login(data: any){
    let url = `${this.baseUrl}/login`;
    return this.httpClient.post<any>(url, data);
  }

  public logout(){
    let url = `${this.baseUrl}/logout`;
    return this.httpClient.post<any>(url, {});
  }

  public checkAuthentication(){
    return this.httpClient.get<any>(this.baseUrl);
  }
}
