export enum IComponentKey {
  Hi = 'Hi',
  Event = 'Events',
  Tasks = 'Tasks',
  Shared = 'Shared Files',
  Recent = 'Recent Files',
  Links = 'Links',
  Notes = 'Notes',
  Video = 'Video',
}

export interface IContentResponse {
  mainContentArea: {
    expandedValue: IContentProperties[];
  };
}

export interface IContentProperties {
  name: IComponentKey;
  subTitle?: IProperty;
  sectionTitle: IProperty;
}

export interface IProperty {
  value: string;
}

export interface IContent {
  type: IComponentKey;
  title: string;
  subTitle?: string;
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
