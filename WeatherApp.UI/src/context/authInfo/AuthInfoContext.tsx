import React, { useContext } from "react";
import { authInfoInitialState, IAuthInfoAction, IAuthInfoState } from "./AuthInfoState";
import { LoadingContext, ILoadingContext } from "../loading/LoadingContext";
import axios from "axios";
import { getLocalStorageItem, removeLocalStorageItem, setLocalStorageItem } from "../../localStorage";
import { AlertContext, IAlertContext } from "../alert/AlertContext";
import { authInfoReducer } from "./AuthInfoReducer";

//https://dev.to/manuartero/testing-a-react-context-provider-5cfg
//https://medium.com/@jan.hesters/unit-testing-reducers-2df09bb6ba61

export interface IAuthInfoContext {
  authInfo: IAuthInfoState | undefined;
  login: (userName: string, password: string) => void;
  logout: () => void;
  register: (username: string, password: string) => void;
}

export const AuthInfoContext = React.createContext<IAuthInfoContext | undefined>(undefined);

const AuthInfoProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
  const localStorage: IAuthInfoState | undefined = getLocalStorageItem('auth');

  const init = localStorage?.user ? localStorage : authInfoInitialState;
  const [state, dispatch] = React.useReducer<React.Reducer<IAuthInfoState, IAuthInfoAction>>(authInfoReducer, init);

  const { setLoadingTrue, setLoadingFalse } = useContext(LoadingContext) as ILoadingContext;
  const { setAlert } = useContext(AlertContext) as IAlertContext;

  const saveAuthInfo = (newAuth: IAuthInfoState) => {
    setLocalStorageItem('auth', newAuth);
  }

  const removeAuthInfo = () => {
    removeLocalStorageItem('auth');

  }

  const login = async (userName: string, password: string) => {
    setLoadingTrue();
    await axios.post(`https://api-weather-app-dev-001.azurewebsites.net/api/v1/Login`, {
      userName,
      password
    })
      .then((response) => {
        dispatch({ type: 'LOGIN', payload: response.data });
        saveAuthInfo(response.data);
        setAlert('Login Success', 'success');
      })
      .catch((error) => {
        const errorMessage = error.response.data.title ? error.response.data.title : error.message;
        setAlert(errorMessage, 'error');
      });
    setLoadingFalse();
  }

  const logout = () => {
    dispatch({ type: 'LOGOUT', payload: authInfoInitialState });
    removeAuthInfo();
  }

  const register = async (userName: string, password: string) => { console.error('Not Implemented') }

  return <AuthInfoContext.Provider value={{ authInfo: state, login, logout, register }}>{children}</AuthInfoContext.Provider>;
}

export default AuthInfoProvider;