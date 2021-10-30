import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Store } from '@ngrx/store';
import * as moment from 'moment';
import { AuthModel, IAuthModel } from 'src/app/models/auth-model';
import { Booking } from 'src/app/models/booking-model';
import { CovidTestResult } from 'src/app/models/covid-test-result-model';
import { CovidTestResultsService } from 'src/app/services/covid-test-results.service';
import { getIsAuthenticated, getUser } from 'src/app/stores/auth.reducer';

@Component({
  selector: 'app-add-test-result',
  templateUrl: './add-test-result.component.html',
  styleUrls: ['./add-test-result.component.scss']
})
export class AddTestResultComponent implements OnInit {

  public isAuthenticated:boolean = false;
  public user?: AuthModel = new AuthModel();
  public types: string[] = ['PCR', 'Rapid Antigen'];
  public results: string[] = ['Positive', 'Negative'];
  public booking: Booking = new Booking();

  public result:CovidTestResult = new CovidTestResult();

  constructor(
    private store: Store<{ auth: IAuthModel }>,
    private resultsService: CovidTestResultsService,
    public dialogRef: MatDialogRef<AddTestResultComponent>,
    @Inject(MAT_DIALOG_DATA) public data:any) {
      this.booking = data.booking;
      this.result.bookingId = this.booking.id;
      this.result.dateTested = moment().format('yyyy-MM-DD');
      this.result.result = this.results[0];
      this.result.type = this.types[0];
    }

  ngOnInit(): void {
    this.store.select(getIsAuthenticated).subscribe(state => {
      this.isAuthenticated = state;
    });

    this.store.select(getUser).subscribe(state => {
      this.user = state;
    })
  }

  public typeChanged(event:any){
    this.result.type = event.target.value;
  }

  public resultsChanged(event:any){
    this.result.result = event.target.value;
  }

  public addTestResult(){
    this.resultsService.addCovidTestResult(this.result)
      .subscribe(res => {
        this.dialogRef.close(true);
      }, err => {
        console.error('addTestResult: ', err);
      })
  }

  public closeDialog(){
    this.dialogRef.close(false);
  }
}
