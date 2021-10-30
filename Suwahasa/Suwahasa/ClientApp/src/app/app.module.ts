import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';

import { EmployeesService } from './services/employees.service';
import { HospitalsService } from './services/hospitals.service';
import { EmployeeManagementComponent } from './components/employee-management/employee-management.component';
import { HospitalManagementComponent } from './components/hospital-management/hospital-management.component';
import { AddOrEditHospitalComponent } from './components/hospital-management/add-or-edit-hospital/add-or-edit-hospital.component';
import { AddOrEditEmployeeComponent } from './components/employee-management/add-or-edit-employee/add-or-edit-employee.component';
import { VehicleManagementComponent } from './components/vehicle-management/vehicle-management.component';
import { VehiclesService } from './services/vehicles.service';
import { AddOrEditVehicleComponent } from './components/vehicle-management/add-or-edit-vehicle/add-or-edit-vehicle.component';
import { ManageHospitalComponent } from './components/hospital-management/manage-hospital/manage-hospital.component';
import { AddOrEditPackageComponent } from './components/hospital-management/add-or-edit-package/add-or-edit-package.component';
import { PackagesService } from './services/packages.service';
import { LoginComponent } from './components/authentication/login/login.component';
import { RegisterComponent } from './components/authentication/register/register.component';
import { HospitalInfoComponent } from './components/dashboard/hospital-info/hospital-info.component';
import { AuthService } from './services/auth.service';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { MatButtonModule } from '@angular/material/button';
import { StoreModule } from '@ngrx/store';
import { authReducer } from './stores/auth.reducer';
import { MakeReservationComponent } from './components/reservation-management/make-reservation/make-reservation.component';
import { ViewReservationComponent } from './components/reservation-management/view-reservation/view-reservation.component';
import { DoctorsViewComponent } from './components/doctors-view/doctors-view.component';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { environment } from '../environments/environment';
import { AddTestResultComponent } from './components/doctors-view/add-test-result/add-test-result.component';
import { AddObservationComponent } from './components/doctors-view/add-observation/add-observation.component';

@NgModule({
  declarations: [
    AppComponent,
    EmployeeManagementComponent,
    HeaderComponent,
    FooterComponent,
    HospitalManagementComponent,
    AddOrEditHospitalComponent,
    AddOrEditEmployeeComponent,
    VehicleManagementComponent,
    AddOrEditVehicleComponent,
    ManageHospitalComponent,
    AddOrEditPackageComponent,
    LoginComponent,
    RegisterComponent,
    DashboardComponent,
    HospitalInfoComponent,
    MakeReservationComponent,
    ViewReservationComponent,
    DoctorsViewComponent,
    AddTestResultComponent,
    AddObservationComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatPaginatorModule,
    MatIconModule,
    MatDialogModule,
    FormsModule,
    MatCardModule,
    MatButtonModule,
    MatDividerModule,
    StoreModule.forRoot({ auth: authReducer }),
    StoreDevtoolsModule.instrument({
      name: 'Suwahasa App Dev Tools',
      maxAge: 25,
      logOnly: environment.production
    })
  ],
  providers: [EmployeesService, HospitalsService, VehiclesService, PackagesService, AuthService],
  bootstrap: [AppComponent],
  exports: [MatSortModule]
})
export class AppModule { }
