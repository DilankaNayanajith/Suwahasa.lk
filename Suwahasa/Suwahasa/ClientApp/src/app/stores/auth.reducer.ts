import { state } from '@angular/animations';
import { createFeatureSelector, createReducer, createSelector, on } from '@ngrx/store';
import { IAuthModel } from '../models/auth-model';
import { login, reset } from './auth.actions';

export const initialState: IAuthModel = {
  isAuthenticated: false,
  user: undefined
};

const getAuthState = createFeatureSelector<IAuthModel>('auth');
export const getIsAuthenticated = createSelector(
  getAuthState,
  state => state.isAuthenticated
)

export const getUser = createSelector(
  getAuthState,
  state => state.user
)

export const authReducer = createReducer<IAuthModel>(
  initialState,
  on(login, (state, action): IAuthModel => {
    return {
      ...state,
      isAuthenticated: true,
      user: action.user,
    };
  }),
  on(reset, (state) => {
    return {
      ...state,
      isAuthenticated: false,
      user: undefined,
    };
  })
);



