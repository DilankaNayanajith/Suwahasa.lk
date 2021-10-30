import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { BedTicket } from '../models/bed-ticket-model';
import { CovidTestResult } from '../models/covid-test-result-model';

@Injectable({
  providedIn: 'root'
})
export class ObservationsService {
  private api = environment.baseUrl;
  private baseUrl = `${this.api}/api/BedTickets`;

  constructor(private httpClient: HttpClient) { }

  public addObservation(observation:BedTicket){
    return this.httpClient.post<any>(`${this.baseUrl}`, observation);
  }
}
