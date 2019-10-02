import isDebug from '../../../utils/isDebug';

import { IComponentKey } from './types';

import { getMockedIntranetBlocks } from '../mocks';

export * from './types';

export function getIntranetBlocks(): IComponentKey[] {
  if (isDebug) {
    return getMockedIntranetBlocks();
  }
  return [];
}
