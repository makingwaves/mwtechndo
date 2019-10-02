import { api } from '../api';
import isDebug from 'common/utils/isDebug';

import { normalizeUserData, normalizeUserEvents, normalizeUserTasks, normalizeUserSharedFiles } from './normalizers';
import {
  IUserResponse,
  IUser,
  IEventsResponse,
  IEvent,
  ITask,
  ITasksResponse,
  ISharedFile,
  ISharedFilesResponse,
} from './types';

import { getMockedUserData, getMockedUserEvents, getMockedUserTasks, getMockedSharedFiles } from '../mocks';

export * from './types';

export const getUserData = (): Promise<IUser> => {
  if (isDebug) {
    return Promise.resolve(getMockedUserData());
  }
  return api.get<IUser, IUserResponse>(`/me`).then(normalizeUserData);
};

export const getUserEvents = (): Promise<IEvent[]> => {
  if (isDebug) {
    return Promise.resolve(getMockedUserEvents());
  }
  return api.get<IEvent[], IEventsResponse>(`/me/events`).then(normalizeUserEvents);
};

export const getUserTasks = (): Promise<ITask[]> => {
  if (isDebug) {
    return Promise.resolve(getMockedUserTasks());
  }
  return api.get<ITask[], ITasksResponse>(`/me/planner/tasks`).then(normalizeUserTasks);
};

export const getUserSharedFiles = (): Promise<ISharedFile[]> => {
  if (isDebug) {
    return Promise.resolve(getMockedSharedFiles());
  }
  return api.get<ISharedFile[], ISharedFilesResponse>(`/me/drive/sharedWithMe`).then(normalizeUserSharedFiles);
};
