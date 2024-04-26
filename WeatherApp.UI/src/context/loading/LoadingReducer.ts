import { ILoadingAction, ILoadingState } from "./LoadingState";

export const loadingReducer: React.Reducer<ILoadingState, ILoadingAction> = (
  state,
  action
) => {
  switch (
    action.type //'CLEAR_USERS'
  ) {
    case "SET":
      return {
        loading: true,
      };
    case "CLEAR":
      return {
        loading: false,
      };
    default:
      return state;
  }
};
