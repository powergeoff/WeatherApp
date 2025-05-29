import { IAuthInfoAction, IAuthInfoState } from './AuthInfoState';

export const authInfoReducer: React.Reducer<IAuthInfoState, IAuthInfoAction> = (state, action) => {
  switch (action.type) {
    case 'LOGIN': //register would log the user in
      return action.payload;
    case 'LOGOUT':
      return action.payload; //payload should be initial user
    default:
      return state;
  }
};
