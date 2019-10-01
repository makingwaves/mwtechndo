import { IUserResponse, IUser } from "../types";

export const normalizeUserData = (user: IUserResponse): IUser => {
  return {
    mail: user.mail || '',
    givenName: user.givenName || '',
    mobilePhone: user.mobilePhone || '',
    displayName: user.displayName || '',
  }
}