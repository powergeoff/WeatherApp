import * as React from 'react';
import { AuthInfoModel, AuthInfoModelContextType } from '../models/authInfoModel';
import { getLocalStorageItem, setLocalStorageItem, removeLocalStorageItem } from "../api/localStorage";
import { User } from '../models/user';

const initialUser: User = {
  activityLevel: 0,
  bodyTemp: 0,
  userName: '',
  role: 'User'
}

export const AuthInfoContext = React.createContext<AuthInfoModelContextType | undefined>(undefined);

const AuthInfoProvider: React.FC<{children: React.ReactNode}> = ({ children }) => {

  const localStorage: AuthInfoModel | undefined = getLocalStorageItem('auth');
  //read expire time from auth??

  const init = localStorage?.user ? localStorage.user : initialUser;

  const [authInfoModel, setAuthInfoModel] = React.useState<AuthInfoModel>({
    user: init,
    token: '',
    expires: undefined
  })

  const saveAuthInfo = (newAuth: AuthInfoModel) => {
    setLocalStorageItem('auth', newAuth);
    setAuthInfoModel(newAuth);
  }

  const removeAuthInfo = () => {
    removeLocalStorageItem('auth');
    setAuthInfoModel(
      {...authInfoModel, 
        user: {...initialUser},
        token: '',
        expires: new Date()
      }
  );
  }

  return (
    <AuthInfoContext.Provider value={{ authInfoModel, saveAuthInfo, removeAuthInfo}}>
      {children}
    </AuthInfoContext.Provider>
  )
};

export default AuthInfoProvider;