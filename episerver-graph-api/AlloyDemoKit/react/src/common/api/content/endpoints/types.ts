export enum IComponentKey {
  Hi = 'AccountBlock',
  Event = 'EventsBlock',
  Tasks = 'TasksBlock',
  Shared = 'SharedFilesBlock',
  Recent = 'RecentFilesBlock',
  Links = 'LinksBlock',
}

export interface IGeneralUser {
  userFullName: string;
  userPhotoUrl: string;
}

export interface IHeaderData extends IGeneralUser {
  logoUrl: string;
}

export interface ILinksResponse {}

export interface ILink {
  id: string;
  name: string;
  logoUrl: string;
}

// blocks: [
//   "Hi",
//   "Events",
//   "Tasks",
//   "Shared Files",
//   "Recent Files",
//   "Links",
//   "Apps",
//   "Poster",
//   "Video",
//   "Notes",
// ]
