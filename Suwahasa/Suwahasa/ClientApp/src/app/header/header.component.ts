import { Component, Input, OnInit } from '@angular/core';
import { async } from '@angular/core/testing';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { AuthModel, IAuthModel } from '../models/auth-model';
import { AuthService } from '../services/auth.service';
import { reset } from '../stores/auth.actions';
import { getIsAuthenticated, getUser } from '../stores/auth.reducer';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  public isAuthenticated:boolean = false;
  public user?: AuthModel = new AuthModel();

  constructor(
    private store: Store<{ auth: IAuthModel }>,
    private router: Router,
    private authService: AuthService)
  {
    store.select(getIsAuthenticated).subscribe(state => {
      this.isAuthenticated = state;
    });

    store.select(getUser).subscribe(state => {
      this.user = state;
    })
  }

  public signout():void{
    this.authService.logout().subscribe(res => {
      this.store.dispatch(reset());
      this.router.navigate(["/"]);
    }, err => {
      console.error('HeaderComponent: logout: ', err);
    })
  }

  ngOnInit(): void {
    console.log('inputAutheticated: ', this.isAuthenticated);
  }

}
