import { BedTicket } from "./bed-ticket-model";
import { CovidTestResult } from "./covid-test-result-model";
import { Hospital } from "./hospital-model";
import { Package } from "./package-model";
import { User } from "./user-model";
import { Vehicle } from "./vehicle-model";

export class Booking {
  public id: number = 0;
  public hospitalFk: number = 0;
  public packageFk: number = 0;
  public dateCreated: string = '';
  public dateCreatedText: string = '';
  public transportRequested: boolean = false;
  public transportDate: string = '';
  public transportDateText = '';
  public vehicleFk: number = 0;
  public dateAdmitted: string = '';
  public dateAdmittedText: string = '';
  public dateDischarged: string = '';
  public dateDischargedText: string = '';
  public paymentStatus: string = '';
  public transportApproved: boolean = false;
  public reservationDate: string = '';
  public reservationDateText: string = '';
  public userFk: number = 0;
  public isActive: boolean = false;
  public reservedHospital?: Hospital;
  public reservedPackage?: Package;
  public reservedVehicle?: Vehicle;
  public reservedUser?: User;
  public bedTickets?:BedTicket[] = [];
  public covidTestResults?:CovidTestResult[] = [];
}
