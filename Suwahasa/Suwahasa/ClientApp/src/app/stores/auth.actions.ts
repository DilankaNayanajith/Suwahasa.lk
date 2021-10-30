import { createAction, props } from '@ngrx/store';
import { AuthModel } from '../models/auth-model';

export const login = createAction(
  '[Auth Component] Login',
  props<{ user: AuthModel }>()
);
export const reset = createAction('[Auth Component] Reset');
