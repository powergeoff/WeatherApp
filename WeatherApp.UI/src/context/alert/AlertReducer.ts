import { IAlertAction, IAlertState } from "./AlertState";

export const alertReducer: React.Reducer<IAlertState, IAlertAction> = (
  state,
  action
) => {
  switch (action.type) {
    case "SET":
      return action.payload;
    case "CLEAR":
      return action.payload;
    default:
      return state;
  }
};
