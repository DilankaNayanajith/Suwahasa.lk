import { Employee } from "./employee-model";
import { Package } from "./package-model";
import { Vehicle } from "./vehicle-model";

export class Hospital {
    public id:number = 0;
    public name?: string;
    public category?: string;
    public subcategory?: string;
    public addressLine1?: string;
    public addressLine2?: string;
    public city?: string;
    public district?: string;
    public province?: string;
    public postalCode?: string;
    public phone?: string;
    public covidPatientCount?: number = 0;
    public dischargedCovidPatientCount?: number = 0;
    public icuBedCount?: number = 0;
    public availableOxygen?: number = 0.0;
    public wardDescription?: string;
    public sanitaryDetails?: string;
    public mealsDetails?: string;
    public activeDoctors?: number = 0;
    public activeNurses?: number = 0;
    public availableAmbulances?: number = 0;
    public costPerPatient?: number = 0.0;
    public packages: Package[] = [];
    public employees: Employee[] = [];
    public vehicles: Vehicle[] = [];
}
