export enum IComponentKey {
  Hi = 'AccountBlock',
  Event = 'EventsBlock',
  Tasks = 'TasksBlock',
  Shared = 'SharedFilesBlock',
  Recent = 'RecentFilesBlock',
}

export interface IGeneralUser {
  userFullName: string;
  userPhotoUrl: string;
}

export interface IHeaderData extends IGeneralUser {
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
