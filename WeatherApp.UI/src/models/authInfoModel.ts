import { User } from "./user";

export interface AuthInfoModel{
  user?: User;
  token?: string;
  expires?: Date; //not necessary - token handles all of it
}