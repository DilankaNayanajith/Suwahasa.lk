import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { AuthService } from './services/auth.service';
import { login, reset } from './stores/auth.actions';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent {
  title = 'suwahasa-client';
  public isAutheticated: boolean = false;
  public user: any = null;

  public isAuthenticated: Observable<boolean>;

  constructor(
    private authService: AuthService,
    private store: Store<{  isAuthenticated: boolean }>){
      this.isAuthenticated = store.select('isAuthenticated');
    }

  ngOnInit(): void {
    this.authService.checkAuthentication()
      .subscribe(res => {
        this.user = res;
        this.isAutheticated = true;
        this.store.dispatch(login({ user: res }));
      }, err => {
        this.store.dispatch(reset());
        console.error('Unauthorized: ', err);
      })
  }
}
