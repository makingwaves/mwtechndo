import { IComponentKey, IHeaderData, ILink, IBrand, ISocials, IRecentlyApps } from '../endpoints';

export const getMockedIntranetBlocks = (): IComponentKey[] => {
  return [
    IComponentKey.Hi,
    IComponentKey.Event,
    IComponentKey.Tasks,
    IComponentKey.Shared,
    IComponentKey.Recent,
    IComponentKey.Video,
    IComponentKey.Links,
    IComponentKey.Notes,
  ];
};

export const getMockedHeaderData = (): IHeaderData => {
  return {
    logoUrl: 'http://www.kariera.wse.krakow.pl/jsjobsdata/data/employer/comp_672/logo/MW_logo_symbol_black.png',
    userFullName: 'Krzysztof Nofz',
    userPhotoUrl:
      'https://scontent-frx5-1.xx.fbcdn.net/v/t1.0-9/50869005_2009689985767139_7266709714187059200_n.jpg?_nc_cat=110&_nc_oc=AQkfLRg0cyUwhw5vjMF1a4SKqNuTLpCmdo6BgxGpnuZUozyqaprAgGqwkFnqamYoltQ&_nc_ht=scontent-frx5-1.xx&oh=2002e1d250bb221a2a2ccfb6d0011828&oe=5E1EC94A',
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

export const getMockedRecentlyUsedApps = (): IRecentlyApps[] => {
  return [
    {
      id: '1',
      appUrl: 'https://products.office.com/pl-pl/microsoft-teams/group-chat-software',
      logoUrl: 'https://www.clipartmax.com/png/middle/19-193109_microsoft-teams-microsoft-teams-logo-vector.png',
      displayName: 'Microsoft Teams',
    },
    {
      id: '2',
      appUrl: 'https://onedrive.live.com/about/pl-pl/',
      logoUrl: 'http://pluspng.com/img-png/onedrive-logo-vector-png--460.png',
      displayName: 'Microsoft OneDrive',
    },
    {
      id: '3',
      appUrl: 'https://products.office.com/pl-pl/onenote/digital-note-taking-app',
      logoUrl:
        'https://www.pinclipart.com/picdir/middle/249-2491946_onenote-png-clipart-microsoft-onenote-microsoft-powerpoint-transparent.png',
      displayName: 'Microsoft OneNote',
    },
    {
      id: '4',
      appUrl: 'https://outlook.live.com/owa/',
      logoUrl:
        'https://i7.pngguru.com/preview/1008/25/122/outlook-com-microsoft-outlook-email-computer-icons-microsoft.jpg',
      displayName: 'Microsoft Outlook',
    },
  ];
};
