export enum IComponentKey {
  Hi = 'AccountBlock',
  Event = 'EventsBlock',
  Tasks = 'TasksBlock',
  Shared = 'SharedFilesBlock',
  Recent = 'RecentFilesBlock',
  Links = 'LinksBlock',
  Notes = 'NotesBlock',
  Video = 'VideoBlock',
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

export interface IBrand {
  name: string;
  logoUrl: string;
  policyUrl: string;
  description: string;
}

export interface ISocials {
  linkedin: string;
  facebook: string;
  instagram: string;
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
