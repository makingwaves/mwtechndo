import { isDebug } from 'common/utils';

import { IComponentKey, IHeaderData, ILink } from './types';

import { getMockedIntranetBlocks, getMockedHeaderData, getMockedLinks } from '../mocks';

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

export const getLinks = (): Promise<ILink[]> => {
  if (isDebug) {
    return Promise.resolve(getMockedLinks());
  }
  return Promise.resolve([]);
};
