import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CovidTestResult } from '../models/covid-test-result-model';

@Injectable({
  providedIn: 'root'
})
export class CovidTestResultsService {
  private api = environment.baseUrl;
  private baseUrl = `${this.api}/api/CovidTestResults`;

  constructor(private httpClient: HttpClient) { }

  public addCovidTestResult(result:CovidTestResult){
    return this.httpClient.post<any>(`${this.baseUrl}`, result);
  }
}
