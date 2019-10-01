import { IUser } from "../endpoints";

export const getMockedUserData = (): IUser => {
  return {
    mail: 'krzysztof.nofz@makingwaves.com',
    givenName: 'Krzysztof',
    mobilePhone: '+48882433272',
    displayName: 'Krzysztof Nofz',
  }
}