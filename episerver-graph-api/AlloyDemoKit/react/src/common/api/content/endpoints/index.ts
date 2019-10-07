import { isDebug } from 'common/utils';

import { normalizeContent } from './normalizers';
import { IHeaderData, ILink, IBrand, ISocials, IContent, IRecentlyApps } from './types';

import {
  getMockedHeaderData,
  getMockedLinks,
  getMockedBrand,
  getMockedSocial,
  getMockedRecentlyUsedApps,
} from '../mocks';

export * from './types';

export const getContent = (): Promise<IContent[]> => {
  if (isDebug) {
    return import('../mocks/contentFile.json').then(normalizeContent);
  }
  return {} as Promise<IContent[]>;
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

export const getRecentlyUsedApps = (): Promise<IRecentlyApps[]> => {
  if (isDebug) {
    return Promise.resolve(getMockedRecentlyUsedApps());
  }
  return Promise.resolve([]);
};
