import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { AuthModel, IAuthModel } from 'src/app/models/auth-model';
import { Booking } from 'src/app/models/booking-model';
import { Hospital } from 'src/app/models/hospital-model';
import { BookingsService } from 'src/app/services/bookings.service';
import { HospitalsService } from 'src/app/services/hospitals.service';
import { getIsAuthenticated, getUser } from 'src/app/stores/auth.reducer';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  public hospitals: Hospital[] = [];
  public searchKey: string = '';
  public bookings: Booking[] = [];
  public activeBooking?: Booking;
  public isAuthenticated:boolean = false;
  public user?: AuthModel = new AuthModel();

  constructor(
    private hospitalsService: HospitalsService,
    private bookingsService: BookingsService,
    private route: ActivatedRoute,
    private router: Router,
    private store: Store<{ auth: IAuthModel }>) { }

  ngOnInit(): void {
    this.searchHospitalsByCity('');
    this.getActiveReservation();
    this.store.select(getIsAuthenticated).subscribe(state => {
      this.isAuthenticated = state;
    });

    this.store.select(getUser).subscribe(state => {
      this.user = state;
      if (this.user){
        this.getActiveReservation();
      }
    })
  }

  getActiveReservation(): void {
    //add current user id
    if (this.isAuthenticated && this.user){
    this.bookingsService.getActiveReservation(this.user?.id!)
      .subscribe(res => {
        this.activeBooking = res;
        //console.log('activeBooking: ', this.activeBooking);
      }, err => {
        console.error('DashboardComponent: getActiveReservation: ', err);
      })
    }
  }

  goToReservationPage(): void {
    this.router.navigate([`/reservations/${this.activeBooking?.id}`]);
  }

  getMyReservations(): void {
    this.bookingsService.getBookingsByUserId(1)
      .subscribe(res => {

      }, err => {
        console.error('DashboardComponent: getMyReservations: ', err);
      });
  }

  searchHospitals(event:any){
    this.searchHospitalsByCity(event.target.value);
  }

  searchHospitalsByCity(city: string){
    this.hospitalsService.getHospitalByCity(city).subscribe(res => {
      this.hospitals = res;
    }, err => {
      console.log('DashboardComponent: searchHospitalsByCity: ', err);
    })
  }

  onHospitalCardClicked(data: any){
    this.router.navigate([`/hospital`, { id: data.id }]);
  }
}
