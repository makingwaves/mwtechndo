import React, { FunctionComponent, ComponentType } from 'react';

import { IComponentKey, IContent } from 'common/api';

import TaskBlock from './../TaskBlock/TaskBlock';
import EventBlock from './../EventBlock/EventBlock';
import LinksBlock from './../LinksBlock';
import NotesBlock from './../NotesBlock';
import StreamBlock from './../StreamBlock';
import PosterBlock from '../PosterBlock';
import AccountBlock from './../AccountBlock';
import SharedFilesBlock from './../SharedFilesBlock';
import RecentFilesBlock from './../RecentFilesBlock';
import RecentyAppsBlock from '../RecentyAppsBlock';

type DynamicComponentsProps = {
  ownProps: IContent;
  componentKey: IComponentKey;
};

const components: { [key in IComponentKey]: ComponentType<IContent> } = {
  [IComponentKey.Hi]: AccountBlock,
  [IComponentKey.Event]: EventBlock,
  [IComponentKey.Tasks]: TaskBlock,
  [IComponentKey.Shared]: SharedFilesBlock,
  [IComponentKey.Recent]: RecentFilesBlock,
  [IComponentKey.Links]: LinksBlock,
  [IComponentKey.Notes]: NotesBlock,
  [IComponentKey.Video]: StreamBlock,
  [IComponentKey.Apps]: RecentyAppsBlock,
  [IComponentKey.Poster]: PosterBlock,
};

const DynamicComponents: FunctionComponent<DynamicComponentsProps> = ({ componentKey, ownProps }) => {
  const Component = components[componentKey];
  if (Component) {
    return <Component {...ownProps} />;
  }
  return null;
};

export default DynamicComponents;
