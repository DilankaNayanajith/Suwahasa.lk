import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Validations } from 'src/app/common/functions';
import { District, districts } from 'src/app/models/common-data';
import { User } from 'src/app/models/user-model';
import { AuthService } from 'src/app/services/auth.service';
import { login, reset } from 'src/app/stores/auth.actions';

@Component({
  selector: "app-register",
  templateUrl: "./register.component.html",
  styleUrls: ["./register.component.scss"],
})
export class RegisterComponent implements OnInit {
  public user: User = new User();
  isAuthenticated: Observable<boolean>;
  public districts: District[] = districts;
  public bloodGroups: string[] = [
    "A+",
    "A-",
    "B+",
    "B-",
    "AB+",
    "AB-",
    "O+",
    "O-",
  ];

  public isValid: boolean = true;
  public invalidText: string = "";

  constructor(
    private router: Router,
    private authService: AuthService,
    private store: Store<{ isAuthenticated: boolean }>
  ) {
    this.user = new User();
    this.user.type = "User";
    this.user.bloodGroup = this.bloodGroups[0];
    this.isAuthenticated = store.select("isAuthenticated");
    this.user.district = this.districts[0].name;
    this.user.province = this.districts[0].province;
  }

  ngOnInit(): void {}

  public onDistrictChange(data: any) {
    let selectedDistrict = data.target.value;
    let index = districts.findIndex((d) => d.name == selectedDistrict);
    this.user.district = districts[index].name;
    this.user.province = districts[index].province;
  }

  public validateUserData(): boolean {
    let status: boolean = true;
    let invalidFields: string[] = [];

    if (!Validations.validateString(this.user.firstName)) {
      invalidFields.push("First Name");
    }

    if (!Validations.validateString(this.user.lastName)) {
      invalidFields.push("Last Name");
    }

    if (
      !(
        Validations.isOnlyNumbers(this.user.age?.toString()) &&
        this.user.age! > 0 &&
        this.user.age! < 120
      )
    ) {
      invalidFields.push("Age");
    }

    if (!Validations.validateNationalId(this.user.nic)) {
      invalidFields.push("National Id");
    }

    if (!Validations.validateEmail(this.user.email)) {
      invalidFields.push("Email");
    }

    if (!Validations.validateContact(this.user.contactNumber)) {
      invalidFields.push("Contact Number");
    }

    if (!Validations.validateString(this.user.addressLine1)) {
      invalidFields.push("Address line 1");
    }

    if (!Validations.validateString(this.user.city)) {
      invalidFields.push("City");
    }

    if (!Validations.validateString(this.user.district)) {
      invalidFields.push("District");
    }

    if (!Validations.validateString(this.user.province)) {
      invalidFields.push("Province");
    }

    if (!Validations.validateString(this.user.parentOrGuardian)) {
      invalidFields.push("Parent/Guardian");
    }

    if (!Validations.validateContact(this.user.emergencyContact)) {
      invalidFields.push("Emergency Contact");
    }

    if (!Validations.validateString(this.user.username)) {
      invalidFields.push("Username");
    }

    if (!Validations.validateString(this.user.password)) {
      invalidFields.push("Password");
    }

    if (invalidFields.length > 0) status = false;

    this.invalidText = Validations.generateInvalidText(invalidFields);

    return status;
  }

  public onRegisterClicked() {
    if (this.validateUserData()) {
      this.authService.register(this.user).subscribe(
        (res) => {
          this.store.dispatch(login({ user: res }));
          this.router.navigate(["/"]);
        },
        (err) => {
          console.error("RegisterComponent: onRegisterClicked: ", err);
        }
      );
      this.isValid = true;
    } else {
      this.isValid = false;
    }
  }

  public onBloodGroupChange(data: any) {
    let value = data.target.value;
    this.user.bloodGroup = value;
    console.log("RegisterComponent: onBloodGroupChange: ", value);
  }

  public onCancelClicked() {
    this.store.dispatch(reset());
    this.router.navigate(["/"]);
  }
}
