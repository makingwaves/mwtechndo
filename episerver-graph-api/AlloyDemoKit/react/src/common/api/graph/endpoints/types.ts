import { User } from '@microsoft/microsoft-graph-types';

export interface IUserResponse extends User {};

export interface IUser {
  mail: string;
  givenName: string;
  displayName: string;
  mobilePhone: string;
};