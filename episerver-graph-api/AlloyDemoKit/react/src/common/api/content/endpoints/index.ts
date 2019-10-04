import { isDebug } from 'common/utils';

import { IComponentKey, IHeaderData, ILink, IBrand, ISocials } from './types';

import {
  getMockedIntranetBlocks,
  getMockedHeaderData,
  getMockedLinks,
  getMockedBrand,
  getMockedSocial,
} from '../mocks';

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

export const getBrand = (): IBrand => {
  if (isDebug) {
    return getMockedBrand();
  }
  return {} as IBrand;
};

export const getSocials = (): ISocials => {
  if (isDebug) {
    return getMockedSocial();
  }
  return {} as ISocials;
};
