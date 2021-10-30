export class AuthModel {
  public id: number = 0;
  public employeeId: number|null = 0;
  public city: string = '';
  public name: string = '';
  public role: string|null = '';
  public hospitalId: number | null = null;

  constructor(){
    this.id = 0;
    this.employeeId = 0;
    this.city = '';
    this.name = '';
    this.role = '';
    this.hospitalId = null;
  }

  public mapFromAuthResponse(data: any){
    this.id = data.id;
    this.employeeId = data.employeeId;
    this.city = data.city;
    this.name = data.name;
    this.role = data.role;
    this.hospitalId = data.hospitalId;
  }
}

export interface IAuthModel {
  isAuthenticated: boolean;
  user?: AuthModel;
}
