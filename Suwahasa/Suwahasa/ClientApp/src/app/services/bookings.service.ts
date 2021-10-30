import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CreateBooking } from '../models/create-booking-model';

@Injectable({
  providedIn: 'root'
})
export class BookingsService {
  private api = environment.baseUrl;
  private baseUrl = `${this.api}/api/Bookings`;

  constructor(private httpClient: HttpClient) { }

  public getBookingById(bookingId:number){
    return this.httpClient.get<any>(`${this.baseUrl}/${bookingId}`);
  }

  public getActiveBookingsByHospitalId(hospitalId:number){
    return this.httpClient.get<any>(`${this.baseUrl}/hospital/${hospitalId}`);
  }

  public getBookingsByUserId(userId:number){
    return this.httpClient.get<any>(`${this.baseUrl}/user/${userId}`);
  }

  public getActiveReservation(userId:number){
    return this.httpClient.get<any>(`${this.baseUrl}/user/${userId}/active`);
  }

  public createReservation(booking:CreateBooking) {
    return this.httpClient.post<any>(`${this.baseUrl}`, booking);
  }
}
