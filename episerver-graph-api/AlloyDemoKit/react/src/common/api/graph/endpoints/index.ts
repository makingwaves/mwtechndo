import { api } from '../api';
import isDebug from 'common/utils/isDebug';

import { normalizeUserData } from './normalizers';
import { IUserResponse, IUser } from './types';

import { getMockedUserData } from '../mocks';

export * from './types';

export const getUserData = (): Promise<IUser> => {
  if (isDebug) {
    return Promise.resolve(getMockedUserData());
  }
  return api.get<IUser, IUserResponse>(`/me`).then(normalizeUserData);
};
