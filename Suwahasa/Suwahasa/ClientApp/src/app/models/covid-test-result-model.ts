import * as moment from "moment";

export class CovidTestResult{
    public id:number = 0;
    public bookingId: number = 0;
    public type?: string;
    public dateTested?: string;
    public result?: string;

    constructor(){
      this.dateTested =  moment().format('yyyy-MM-DD');
    }
}
