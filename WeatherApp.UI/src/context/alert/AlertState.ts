export type IAlertType = "error" | "warning" | "info" | undefined;

export interface IAlertState {
  alert: string | undefined;
  type: IAlertType;
}

export interface IAlertAction {
  type: "CLEAR" | "SET";
  payload: IAlertState;
}

export const alertInitialState: IAlertState = {
  alert: undefined,
  type: undefined,
};
