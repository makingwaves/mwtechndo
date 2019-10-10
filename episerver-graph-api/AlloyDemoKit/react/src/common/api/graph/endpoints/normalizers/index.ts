import dayjs from 'dayjs';
import { DateTimeTimeZone, PlannerTask } from '@microsoft/microsoft-graph-types';

import { endsWith } from 'common/utils';
import {
  IUserResponse,
  IUser,
  IEventsResponse,
  IEvent,
  ITask,
  ITasksResponse,
  ISharedFile,
  DocumentType,
  ISharedFilesResponse,
  IRecentFile,
  IRecentFilesResponse,
  IOnenotePagesResponse,
  IOnenoteNote,
  IOnenoteSectionsResponse,
} from '../types';

const getImageType = (name: string): DocumentType => {
  if (endsWith(name, DocumentType.Excel)) {
    return DocumentType.Excel;
  }
  if (endsWith(name, DocumentType.PowerPoint)) {
    return DocumentType.PowerPoint;
  }
  return DocumentType.Word;
};

const getNonNullableValue = <T>(value: T, defaultValue: NonNullable<T>): NonNullable<T> => {
  if (!!value) {
    return value as NonNullable<T>;
  }
  return defaultValue;
};

const formatDate = (date: string, format: string): string => {
  return dayjs(date).format(format);
};

const formatTimezoneTime = (timezone: DateTimeTimeZone | undefined, format: string): string => {
  if (timezone && timezone.dateTime) {
    return formatDate(timezone.dateTime, format);
  }
  return '';
};

export const normalizeUserData = (user: IUserResponse): IUser => {
  return {
    mail: getNonNullableValue(user.mail, 'a'),
    givenName: getNonNullableValue(user.givenName, ''),
    mobilePhone: getNonNullableValue(user.mobilePhone, ''),
  };
};

export const normalizeUserEvents = ({ value }: IEventsResponse): IEvent[] => {
  return value
    .slice(0, 3)
    .map((v, i) => ({
      id: getNonNullableValue(v.id, i.toString()),
      date: formatTimezoneTime(v.start, 'DD/MM/YYYY'),
      subject: getNonNullableValue(v.subject, ''),
      webLink: getNonNullableValue(v.webLink, ''),
      endHour: formatTimezoneTime(v.end, 'HH:mm'),
      startHour: formatTimezoneTime(v.start, 'HH:mm'),
      locationName: v.location ? getNonNullableValue(v.location.displayName, '') : '',
    }))
    .reverse();
};

export const normalizeUserTasks = ({ value }: ITasksResponse): ITask[] => {
  return value.slice(0, 4).map((v, i) => ({
    id: getNonNullableValue(v.id, i.toString()),
    title: getNonNullableValue(v.title, ''),
    dueToDate: formatDate(getNonNullableValue(v.dueDateTime, ''), 'dddd, MMMM DD, YYYYY'),
    isCompleted: !!v.completedDateTime,
  }));
};

export const normalizeUserSharedFiles = ({ value }: ISharedFilesResponse): ISharedFile[] => {
  return value.slice(0, 3).map((v, i) => ({
    id: getNonNullableValue(v.id, i.toString()),
    name: getNonNullableValue(v.name, ''),
    type: getImageType(getNonNullableValue(v.name, '')),
    webUrl: getNonNullableValue(v.webUrl, ''),
    sharedBy: v.createdBy ? getNonNullableValue(v.createdBy.user && v.createdBy.user.displayName, '') : '',
  }));
};

export const normalizeUserRecentOpenedFiles = ({ value }: IRecentFilesResponse): IRecentFile[] => {
  return value.slice(0, 3).map((v, i) => ({
    id: getNonNullableValue(v.id, i.toString()),
    name: getNonNullableValue(v.name, ''),
    type: getImageType(getNonNullableValue(v.name, '')),
    webUrl: getNonNullableValue(v.webUrl, ''),
    updatedBy: v.lastModifiedBy
      ? getNonNullableValue(v.lastModifiedBy.user && v.lastModifiedBy.user.displayName, '')
      : '',
    lastUpdate: formatDate(getNonNullableValue(v.lastModifiedDateTime, ''), 'DD/MM/YYYY'),
  }));
};

export const normalizeOnenotePages = ({ value }: IOnenotePagesResponse): IOnenoteNote[] => {
  return value.map((v, i) => ({
    id: getNonNullableValue(v.id, i.toString()),
    name: getNonNullableValue(v.title, ''),
    webUrl: v.links ? getNonNullableValue(v.links.oneNoteClientUrl && v.links.oneNoteClientUrl.href, '') : '',
  }));
};

export const normalizeOnenoteSections = ({ value }: IOnenoteSectionsResponse): IOnenoteNote[] => {
  return value.map((v, i) => ({
    id: getNonNullableValue(v.id, i.toString()),
    name: getNonNullableValue(v.displayName, ''),
    webUrl: v.links ? getNonNullableValue(v.links.oneNoteClientUrl && v.links.oneNoteClientUrl.href, '') : '',
  }));
};

export const normalizeOnenoteNotes = ([pages, sections]: [IOnenoteNote[], IOnenoteNote[]]): IOnenoteNote[] => {
  return [...pages, ...sections];
};

export const normalizeCompletedTask = (task: PlannerTask): ITask => {
  return {
    id: getNonNullableValue(task.id, ''),
    title: getNonNullableValue(task.title, ''),
    dueToDate: formatDate(getNonNullableValue(task.dueDateTime, ''), 'dddd, MMMM DD, YYYYY'),
    isCompleted: !!task.completedDateTime,
  };
};
