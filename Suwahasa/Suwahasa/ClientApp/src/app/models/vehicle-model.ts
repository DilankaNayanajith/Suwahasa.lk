import { Employee } from "./employee-model";
import { Hospital } from "./hospital-model";

export class Vehicle {
  public id: number = 0;
  public hospitalFk: number = 0;
  public category?: string;
  public driverFk: number = 0;
  public available: boolean = true;
  public availableText?: string;
  public vehicleNumber?: string;
  public make?: string;
  public model?: string;
  public type?: string;
  public driver?: Employee;
  public hospital?: Hospital;
}
