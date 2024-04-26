import React from "react";
import { alertInitialState, IAlertAction, IAlertState, IAlertType } from "./AlertState";
import { alertReducer } from "./AlertReducer";

export interface IAlertContext {
    setAlert: (alert: string, type: IAlertType) => void;
    clearAlert: () => void;
    alert: IAlertState;
}

export const AlertContext = React.createContext<IAlertContext | undefined>(
    undefined
);

const AlertProvider: React.FC<{ children: React.ReactNode }> = ({
    children,
}) => {
    const [state, dispatch] = React.useReducer<React.Reducer<IAlertState, IAlertAction>>(alertReducer, alertInitialState);

    const setAlert = (alert: string, type: IAlertType) => dispatch({ type: "SET", payload: { alert, type } });

    const clearAlert = () => dispatch({ type: "CLEAR", payload: { alert: undefined, type: undefined } });

    //setTimeout(() => clearAlert(), 6000);

    return (
        <AlertContext.Provider
            value={{ alert: state, setAlert, clearAlert }}
        >
            {children}
        </AlertContext.Provider>
    );
};

export default AlertProvider;
