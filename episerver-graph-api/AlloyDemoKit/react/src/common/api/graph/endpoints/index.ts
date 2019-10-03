import { api } from '../api';
import { isDebug } from 'common/utils';

import {
  normalizeUserData,
  normalizeUserEvents,
  normalizeUserTasks,
  normalizeUserSharedFiles,
  normalizeUserRecentOpenedFiles,
} from './normalizers';
import {
  IUserResponse,
  IUser,
  IEventsResponse,
  IEvent,
  ITask,
  ITasksResponse,
  ISharedFile,
  ISharedFilesResponse,
  IRecentFile,
  IRecentFilesResponse,
} from './types';

import {
  getMockedUserData,
  getMockedUserEvents,
  getMockedUserTasks,
  getMockedSharedFiles,
  getMockedRecentlyOpenedFiles,
} from '../mocks';

export * from './types';

export const getUserData = (): Promise<IUser> => {
  if (isDebug) {
    return Promise.resolve(getMockedUserData());
  }
  return api.get<IUser, IUserResponse>(`/v1.0/me`).then(normalizeUserData);
};

export const getUserEvents = (): Promise<IEvent[]> => {
  if (isDebug) {
    return Promise.resolve(getMockedUserEvents());
  }
  return api.get<IEvent[], IEventsResponse>(`/v1.0/me/events`).then(normalizeUserEvents);
};

export const getUserTasks = (): Promise<ITask[]> => {
  if (isDebug) {
    return Promise.resolve(getMockedUserTasks());
  }
  return api.get<ITask[], ITasksResponse>(`/v1.0/me/planner/tasks`).then(normalizeUserTasks);
};

export const getUserSharedFiles = (): Promise<ISharedFile[]> => {
  if (isDebug) {
    return Promise.resolve(getMockedSharedFiles());
  }
  return api.get<ISharedFile[], ISharedFilesResponse>(`/v1.0/me/drive/sharedWithMe`).then(normalizeUserSharedFiles);
};

export const getUserRecentOpenedFiles = (): Promise<IRecentFile[]> => {
  if (isDebug) {
    return Promise.resolve(getMockedRecentlyOpenedFiles());
  }
  return api.get<IRecentFile[], IRecentFilesResponse>(`/v1.0/me/drive/recent`).then(normalizeUserRecentOpenedFiles);
};
