import { isDebug } from 'common/utils';

import { IComponentKey, IHeaderData } from './types';

import { getMockedIntranetBlocks, getMockedHeaderData } from '../mocks';

export * from './types';

export const getIntranetBlocks = (): IComponentKey[] => {
  if (isDebug) {
    return getMockedIntranetBlocks();
  }
  return [];
};

export const getHeaderData = (): IHeaderData => {
  if (isDebug) {
    return getMockedHeaderData();
  }
  return {} as IHeaderData;
};
