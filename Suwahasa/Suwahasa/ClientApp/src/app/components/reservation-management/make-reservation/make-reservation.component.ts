import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Store } from '@ngrx/store';
import * as moment from 'moment';
import { AuthModel, IAuthModel } from 'src/app/models/auth-model';
import { CreateBooking } from 'src/app/models/create-booking-model';
import { Hospital } from 'src/app/models/hospital-model';
import { Package } from 'src/app/models/package-model';
import { BookingsService } from 'src/app/services/bookings.service';
import { getIsAuthenticated, getUser } from 'src/app/stores/auth.reducer';

@Component({
  selector: 'app-make-reservation',
  templateUrl: './make-reservation.component.html',
  styleUrls: ['./make-reservation.component.scss']
})
export class MakeReservationComponent implements OnInit {
  public date:String = '2020-01-01';
  public package: Package;
  public hospital: Hospital;
  public transportRequests:string[] = ['Yes', 'No'];
  public transportRequiredText = 'No';

  public isAuthenticated:boolean = false;
  public user?: AuthModel = new AuthModel();

  public booking: CreateBooking = new CreateBooking();

  constructor(
    private bookingsService: BookingsService,
    public dialogRef: MatDialogRef<MakeReservationComponent>,
    private store: Store<{ auth: IAuthModel }>,
    @Inject(MAT_DIALOG_DATA) public data:any)
    {
      this.package = data.package;
      this.hospital = data.hospital;

      store.select(getIsAuthenticated).subscribe(state => {
        this.isAuthenticated = state;
      });

      store.select(getUser).subscribe(state => {
        this.user = state;
        this.booking.userId = this.user ? this.user.id : 0;
      })
    }

  ngOnInit(): void {
    this.date = moment().format('YYYY-MM-DD');
    this.booking = new CreateBooking();
    console.log('booking: ', this.booking);
  }

  public transportRequestStatusChanged(event?: any){
    this.booking.transportRequested = event.target.value == 'Yes' ? true : false;
  }

  public createReservation(){
    this.booking.userId = this.user ? this.user.id : 1;
    console.log('createReservation: ', this.booking);
    this.bookingsService.createReservation(this.booking)
      .subscribe(res => {
        this.dialogRef.close(true);
      }, err => {
        console.error('MakeReservationComponent: createReservation: ', err);
      })

  }

  public closeDialog(){
    this.dialogRef.close(false);
  }
}
