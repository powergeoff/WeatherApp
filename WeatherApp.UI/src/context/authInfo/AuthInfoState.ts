import { User } from '../../models/user';

export interface IAuthInfoState {
  user: User | undefined;
  token?: string;
  expires?: Date;
}

export interface IAuthInfoAction {
  type: 'LOGIN' | 'LOGOUT';
  payload: IAuthInfoState;
}

export const authInfoInitialState: IAuthInfoState = {
  user: undefined,
};
