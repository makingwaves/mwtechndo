import React, { FunctionComponent, ComponentType } from 'react';

import { IComponentKey } from 'common/api';

import TaskBlock from './../TaskBlock/TaskBlock';
import EventBlock from './../EventBlock/EventBlock';
import AccountBlock from './../AccountBlock';
import SharedFilesBlock from './../SharedFilesBlock/SharedFilesBlock';

type DynamicComponentsProps = {
  componentKey: IComponentKey;
};

const components: { [key in IComponentKey]: ComponentType } = {
  [IComponentKey.Hi]: AccountBlock,
  [IComponentKey.Event]: EventBlock,
  [IComponentKey.Tasks]: TaskBlock,
  [IComponentKey.Shared]: SharedFilesBlock,
};

const DynamicComponents: FunctionComponent<DynamicComponentsProps> = ({ componentKey, ...rest }) => {
  const Component = components[componentKey];
  return <Component {...rest} />;
};

export default DynamicComponents;
