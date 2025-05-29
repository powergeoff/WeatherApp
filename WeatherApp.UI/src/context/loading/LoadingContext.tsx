import React from "react";
import { ILoadingAction, ILoadingState, loadingInitialState } from "./LoadingState";
import { loadingReducer } from "./LoadingReducer";

export interface ILoadingContext {
    setLoadingTrue: () => void;
    setLoadingFalse: () => void;
    loading: boolean;
}


export const LoadingContext = React.createContext<ILoadingContext | undefined>(undefined);

const LoadingProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
    const [state, dispatch] = React.useReducer<React.Reducer<ILoadingState, ILoadingAction>>(loadingReducer, loadingInitialState);

    const setLoadingTrue = () => dispatch({ type: 'SET' });
    const setLoadingFalse = () => dispatch({ type: 'CLEAR' });

    return <LoadingContext.Provider value={{ loading: state.loading, setLoadingFalse, setLoadingTrue }}>{children}</LoadingContext.Provider>;
}

export default LoadingProvider;