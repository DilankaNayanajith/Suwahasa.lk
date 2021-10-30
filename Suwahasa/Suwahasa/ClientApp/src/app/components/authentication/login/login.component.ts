import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Validations } from 'src/app/common/functions';
import { AuthService } from 'src/app/services/auth.service';
import { login, reset } from '../../../stores/auth.actions';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public username:string = '';
  public password:string = '';

  public isValid:boolean = true;
  public invalidText:string = '';

  isAuthenticated: Observable<boolean>;

  constructor(
    private router: Router,
    private authService: AuthService,
    private store: Store<{  isAuthenticated: boolean }>)
    {
      this.isAuthenticated = store.select('isAuthenticated');
    }

  ngOnInit(): void {
  }

  private validateLoginData():boolean{
    let invalidFields:string[] = [];
    this.invalidText = '';
    let status:boolean = true;
    if (!Validations.validateString(this.username)){
      invalidFields.push('Username');
      status = false;
    }
    if (!Validations.validateString(this.password)){
      invalidFields.push('Password');
      status = false;
    }
    this.invalidText = Validations.generateInvalidText(invalidFields);
    return status;
  }

  public onLoginClicked(){
    if (this.validateLoginData()) {
      this.authService
        .login({ username: this.username, password: this.password })
        .subscribe(
          (res) => {
            console.log('onLoginClicked: ', res);
            this.store.dispatch(login({ user: res }));
            if (res.role == 'User' || res.role == 'Admin' || res.role == 'Driver'){
              this.router.navigate(["/"]);
            }else if (res.role == 'Doctor'){
              this.router.navigate(["/doctor"]);
            }
          },
          (err) => {
            this.store.dispatch(reset());
            console.log("LoginComponent: onLoginClicked: ", err);
          }
        );
      this.isValid = true;
    } else {
      this.isValid = false;
    }
  }

  public onCancelClicked(){
    this.store.dispatch(reset());
    this.router.navigate(['/']);
  }
}
