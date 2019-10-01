import React, { FunctionComponent, ComponentType } from 'react';

import { IComponentKey } from 'common/api';

import AccountBlock from './../AccountBlock';

type DynamicComponentsProps = {
  componentKey: IComponentKey;
};

const components: { [key in IComponentKey]: ComponentType } = {
  [IComponentKey.Hi]: AccountBlock
};

const DynamicComponents: FunctionComponent<DynamicComponentsProps> = ({
  componentKey, ...rest
}) => {
  const Component = components[componentKey];
  return <Component {...rest} />;
}

export default DynamicComponents;
