export interface ILoadingState {
  loading: boolean;
}

export interface ILoadingAction {
  type: "CLEAR" | "SET";
}

export const loadingInitialState: ILoadingState = {
  loading: false,
};
