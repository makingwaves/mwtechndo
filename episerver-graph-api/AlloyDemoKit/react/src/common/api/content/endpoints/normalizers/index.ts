import { IContent, IContentResponse } from './../types';

export const normalizeContent = ({ mainContentArea: { expandedValue: blocks } }: IContentResponse): IContent[] => {
  return blocks
    .filter(b => !!b.name)
    .map(b => ({
      type: b.name,
      title: b.sectionTitle.value,
      subTitle: b.subTitle && b.subTitle.value,
    }));
};
