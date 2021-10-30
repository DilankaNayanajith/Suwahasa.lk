import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/authentication/login/login.component';
import { RegisterComponent } from './components/authentication/register/register.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { HospitalInfoComponent } from './components/dashboard/hospital-info/hospital-info.component';
import { DoctorsViewComponent } from './components/doctors-view/doctors-view.component';
import { EmployeeManagementComponent } from './components/employee-management/employee-management.component';
import { HospitalManagementComponent } from './components/hospital-management/hospital-management.component';
import { ManageHospitalComponent } from './components/hospital-management/manage-hospital/manage-hospital.component';
import { ViewReservationComponent } from './components/reservation-management/view-reservation/view-reservation.component';
import { VehicleManagementComponent } from './components/vehicle-management/vehicle-management.component';

const routes: Routes = [
  { path: '', component: DashboardComponent },
  { path: 'employees', component: EmployeeManagementComponent },
  { path: 'hospital', component: HospitalInfoComponent },
  { path: 'hospitals', component: HospitalManagementComponent },
  { path: 'hospitals/:hospitalId', component: ManageHospitalComponent },
  { path: 'vehicles', component: VehicleManagementComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'reservations/:reservationId', component: ViewReservationComponent },
  { path: 'doctor', component: DoctorsViewComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
