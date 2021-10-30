import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { Store } from '@ngrx/store';
import { AuthModel, IAuthModel } from 'src/app/models/auth-model';
import { Booking } from 'src/app/models/booking-model';
import { BookingsService } from 'src/app/services/bookings.service';
import { getIsAuthenticated, getUser } from 'src/app/stores/auth.reducer';
import { AddObservationComponent } from './add-observation/add-observation.component';
import { AddTestResultComponent } from './add-test-result/add-test-result.component';

@Component({
  selector: 'app-doctors-view',
  templateUrl: './doctors-view.component.html',
  styleUrls: ['./doctors-view.component.scss']
})
export class DoctorsViewComponent implements OnInit {

  public bookings: Booking[] = [];
  public bookingsDataSource = new MatTableDataSource(this.bookings);
  public displayedColumns: string[] = ['name', 'reservationDate', 'actions'];
  public searchKey:string = '';
  public isAuthenticated:boolean = false;
  public user?: AuthModel = new AuthModel();

  constructor(
    public dialog: MatDialog,
    private bookingsService: BookingsService,
    private store: Store<{ auth: IAuthModel }>) { }

  ngOnInit(): void {
    this.getActiveReservations();

    this.store.select(getIsAuthenticated).subscribe(state => {
      this.isAuthenticated = state;
    });

    this.store.select(getUser).subscribe(state => {
      this.user = state;
      this.getActiveReservations();
    })
  }

  onSearchKeyChange(data:any):void{
    console.log('DoctorsViewComponent: onSearchKeyChange: ', data.target.value);
    if (this.bookings){
      let filtered = this.bookings.filter(b => b.reservedUser?.name?.toLowerCase().includes(this.searchKey.toLowerCase()));
      this.bookingsDataSource = new MatTableDataSource(filtered);
    }
  }

  getActiveReservations():void{
    if (this.user && this.user.role == 'Doctor')
    this.bookingsService.getActiveBookingsByHospitalId(this.user.hospitalId!).subscribe(res => {
      this.bookings = res;
      console.log('DoctorsViewComponent: getActiveReservations: ', this.bookings);
      this.bookingsDataSource = new MatTableDataSource(this.bookings);
    }, err => {
      console.error('DoctorsViewComponent: getActiveReservations: ', err);
    })
  }

  public openAddTestResultPage(booking: Booking){
    let dialogRef = this.dialog.open(AddTestResultComponent, {
      width: '800px',
      data: {
        booking
      }
    });
  }

  public openAddObservationPage(booking: Booking){
    let dialogRef = this.dialog.open(AddObservationComponent, {
      width: '800px',
      data: {
        booking
      }
    });
  }
}
