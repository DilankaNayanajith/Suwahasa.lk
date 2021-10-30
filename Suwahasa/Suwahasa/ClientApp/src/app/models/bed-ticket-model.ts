import * as moment from "moment";
import { Employee } from "./employee-model";

export class BedTicket{
    public id: number = 0;
    public enteredById: number = 0;
    public bookingId:number = 0;
    public dateEntered?:string;
    public description?:string
    public enteredBy?: Employee
}

export class CreateObservation{
  public id: number = 0;
  public enteredById: number = 0;
  public bookingId:number = 0;
  public dateEntered?:string;
  public description?:string

  constructor(){
    this.id = 0;
    this.enteredById = 0;
    this.bookingId = 0;
    this.dateEntered = moment().format('yyyy-MM-DD');
    this.description = '';
  }
}
