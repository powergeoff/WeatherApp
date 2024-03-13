import { User } from "./user";

export interface AuthInfoModel{
  user?: User;
  token?: string;
}