import { IComponentKey, IHeaderData } from '../endpoints';

export const getMockedIntranetBlocks = (): IComponentKey[] => {
  return [IComponentKey.Hi, IComponentKey.Event, IComponentKey.Tasks, IComponentKey.Shared, IComponentKey.Recent];
};

export const getMockedHeaderData = (): IHeaderData => {
  return {
    logoUrl: 'http://www.kariera.wse.krakow.pl/jsjobsdata/data/employer/comp_672/logo/MW_logo_symbol_black.png',
    userFullName: 'Krzysztof Nofz',
    userPhotoUrl: 'https://moviesroom.pl/images/0.Aj.MR/Ola/fotki/Klaun_Pennywise_To_2017.jpg',
  };
};
