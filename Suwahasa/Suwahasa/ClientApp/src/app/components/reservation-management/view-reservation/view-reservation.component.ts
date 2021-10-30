import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import { Booking } from 'src/app/models/booking-model';
import { BookingsService } from 'src/app/services/bookings.service';

@Component({
  selector: 'app-view-reservation',
  templateUrl: './view-reservation.component.html',
  styleUrls: ['./view-reservation.component.scss']
})
export class ViewReservationComponent implements OnInit {

  public bookingId: number = 0;
  public reservation?: Booking;
  public observationsDisplayedColumns: string[] = ['date', 'doctor', 'observation'];
  public testResultsDisplayedColumns: string[] = ['date', 'type', 'result'];
  public observationsDataSource = new MatTableDataSource(this.reservation?.bedTickets);
  public testResultsDataSource = new MatTableDataSource(this.reservation?.covidTestResults);

  constructor(
    private router: ActivatedRoute,
    private bookingsService: BookingsService) { }

  ngOnInit(): void {
    this.getBookingId();
  }

  private getBookingId(){
    this.router.params.subscribe(params => {
      this.bookingId = params['reservationId'];
      this.getBooking();
    });
  }

  private getBooking(){
    this.bookingsService.getBookingById(this.bookingId)
      .subscribe(res => {
        this.reservation = res;
        this.observationsDataSource = new MatTableDataSource(this.reservation?.bedTickets);
        this.testResultsDataSource = new MatTableDataSource(this.reservation?.covidTestResults);
        console.log('reservation: ', this.reservation);
      }, err => {
        console.error('ViewReservationComponent: getBooking: ', err);
      })
  }

}
