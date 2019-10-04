import { IComponentKey, IHeaderData, ILink, IBrand, ISocials } from '../endpoints';

export const getMockedIntranetBlocks = (): IComponentKey[] => {
  return [
    IComponentKey.Hi,
    IComponentKey.Event,
    IComponentKey.Tasks,
    IComponentKey.Shared,
    IComponentKey.Recent,
    IComponentKey.Links,
  ];
};

export const getMockedHeaderData = (): IHeaderData => {
  return {
    logoUrl: 'http://www.kariera.wse.krakow.pl/jsjobsdata/data/employer/comp_672/logo/MW_logo_symbol_black.png',
    userFullName: 'Krzysztof Nofz',
    userPhotoUrl: 'https://moviesroom.pl/images/0.Aj.MR/Ola/fotki/Klaun_Pennywise_To_2017.jpg',
  };
};

export const getMockedLinks = (): ILink[] => {
  return [
    {
      id: '1',
      name: 'workbook.net',
      logoUrl: 'https://media.trustradius.com/product-logos/DU/bl/9U8O3XXL71GP-180x180.JPEG',
    },
    {
      id: '2',
      name: 'hr.makingwaves.pl',
      logoUrl: 'https://i.pinimg.com/originals/73/fb/7f/73fb7fb7b9cd1833e16bb4fcef17a962.png',
    },
    {
      id: '3',
      name: 'makingwaves.invisionapp.com',
      logoUrl: 'https://cdn.worldvectorlogo.com/logos/invision.svg',
    },
    {
      id: '4',
      name: 'makingwaves.atlassian.net',
      logoUrl: 'https://www.freelogodesign.org/Content/img/logo-samples/bobbygrill.png',
    },
    {
      id: '6',
      name: 'rejestracja.labalance.com.pl',
      logoUrl:
        'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQq_-YYhPU02IRu4ccHUMW0Z-mo0e9p3HK_zA2LsTl1CqlmgHPc',
    },
  ];
};

export const getMockedBrand = (): IBrand => {
  return {
    name: 'We are Making Waves',
    logoUrl:
      'https://media.licdn.com/dms/image/C4E0BAQF9rMHYgX2-MA/company-logo_200_200/0?e=2159024400&v=beta&t=YT7G_R2EyhrrDalWFT-CiLnqz4AEQb5dcmOCz2mNUt0',
    policyUrl: 'https://onet.pl',
    description: 'A mamber of the NoA family',
  };
};

export const getMockedSocial = (): ISocials => {
  return {
    facebook: 'https://facebook.com',
    linkedin: 'https://linkedin.com',
    instagram: 'https://instagram.com',
  };
};
