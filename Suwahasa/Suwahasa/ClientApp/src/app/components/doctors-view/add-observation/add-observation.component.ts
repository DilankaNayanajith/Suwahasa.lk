import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Store } from '@ngrx/store';
import * as moment from 'moment';
import { AuthModel, IAuthModel } from 'src/app/models/auth-model';
import { BedTicket, CreateObservation } from 'src/app/models/bed-ticket-model';
import { Booking } from 'src/app/models/booking-model';
import { CovidTestResult } from 'src/app/models/covid-test-result-model';
import { CovidTestResultsService } from 'src/app/services/covid-test-results.service';
import { ObservationsService } from 'src/app/services/observations.service';
import { getIsAuthenticated, getUser } from 'src/app/stores/auth.reducer';

@Component({
  selector: 'app-add-observation',
  templateUrl: './add-observation.component.html',
  styleUrls: ['./add-observation.component.scss']
})
export class AddObservationComponent implements OnInit {

  public isAuthenticated:boolean = false;
  public user?: AuthModel = new AuthModel();
  public booking: Booking = new Booking();
  public observation: CreateObservation = new CreateObservation();

  constructor(
    private store: Store<{ auth: IAuthModel }>,
    private ticketService: ObservationsService,
    public dialogRef: MatDialogRef<AddObservationComponent>,
    @Inject(MAT_DIALOG_DATA) public data:any) {
      this.booking = data.booking;
      this.observation.bookingId = this.booking.id;
      this.observation.dateEntered = moment().format('yyyy-MM-DD');
    }

  ngOnInit(): void {
    this.store.select(getIsAuthenticated).subscribe(state => {
      this.isAuthenticated = state;
    });

    this.store.select(getUser).subscribe(state => {
      this.user = state;
      if (this.user){
        this.observation.enteredById = this.user.employeeId!;
      }
    })
  }

  public addObservation(){
    this.ticketService.addObservation(this.observation)
      .subscribe(res => {
        this.dialogRef.close(true);
      }, err => {
        console.error('addObservation: ', err);
      });
  }

  public closeDialog(){
    this.dialogRef.close(false);
  }

}
