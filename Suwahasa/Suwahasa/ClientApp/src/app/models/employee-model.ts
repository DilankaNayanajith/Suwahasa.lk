import { Hospital } from './hospital-model';

export class Employee {
    public id: number = 0;
    public hospitalFk: number = 0;
    public firstName?: string;
    public lastName?: string;
    public name?: string;
    public phone?: string;
    public email?: string;
    public nic?: string;
    public driversLicenseNumber?: string;
    public role?: string;
    public addressLine1?: string;
    public addressLine2?: string;
    public city?: string;
    public district?: string;
    public province?: string;
    public postalCode?: string;
    public specialization?: string;
    public active:boolean = false;
    public activeText?: string;
    public hospital?:Hospital;
    public isAuser?:boolean;
}
