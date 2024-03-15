import { User } from "./user";

export interface AuthInfoModel{
  user?: User;
  token?: string;
  expires?: Date;
}

export type AuthInfoModelContextType = {
  authInfoModel: AuthInfoModel;
  saveAuthInfo: (authInfo: AuthInfoModel) => void;
  removeAuthInfo: () => void;
}