import dayjs from 'dayjs';
import { DateTimeTimeZone } from '@microsoft/microsoft-graph-types';
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
} from '../types';

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
    isCompleted: false,
  }));
};

export const normalizeUserSharedFiles = ({ value }: ISharedFilesResponse): ISharedFile[] => {
  return value.slice(0, 3).map((v, i) => ({
    id: getNonNullableValue(v.id, i.toString()),
    name: getNonNullableValue(v.name, ''),
    type: DocumentType.Excel,
    webUrl: getNonNullableValue(v.webUrl, ''),
    sharedBy: v.createdBy ? getNonNullableValue(v.createdBy.user && v.createdBy.user.displayName, '') : '',
  }));
};
