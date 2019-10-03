import { User, Event, PlannerTask, RemoteItem } from '@microsoft/microsoft-graph-types';

export interface IUserResponse extends User {}

export interface IUser {
  mail: string;
  givenName: string;
  mobilePhone: string;
}

export interface IEventsResponse {
  value: Event[];
}

export interface IEvent {
  id: string;
  date: string;
  toStart?: number;
  subject: string;
  webLink: string;
  endHour: string;
  startHour: string;
  locationName: string;
}

export interface ITasksResponse {
  value: PlannerTask[];
}

export interface ITask {
  id: string;
  title: string;
  dueToDate: string;
  isCompleted: boolean;
}

export interface ISharedFilesResponse {
  value: RemoteItem[];
}

export enum DocumentType {
  PowerPoint = 'pptx',
  Excel = 'xlsx',
  Word = 'doc',
}

export interface ISharedFile {
  id: string;
  name: string;
  type: DocumentType;
  webUrl: string;
  sharedBy: string;
}

export interface IRecentFilesResponse {
  value: RemoteItem[];
}

export interface IRecentFile {
  id: string;
  name: string;
  type: DocumentType;
  webUrl: string;
  updatedBy: string;
  lastUpdate: string;
}
