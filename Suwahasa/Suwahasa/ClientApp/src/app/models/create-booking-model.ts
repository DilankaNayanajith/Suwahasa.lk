import * as moment from "moment";

export class CreateBooking {
  public userId: number = 0;
  public hospitalId: number = 0;
  public packageId: number = 0;
  public reservationDate: string = '';
  public transportRequested: boolean = false;
  public paymentStatus: string = 'Complete';

  constructor(){
    this.userId = 1;
    this.hospitalId = 1;
    this.packageId = 1;
    this.reservationDate = moment().format('yyyy-MM-DD');
    this.transportRequested = false;
    this.paymentStatus = 'Complete';
  }
}
