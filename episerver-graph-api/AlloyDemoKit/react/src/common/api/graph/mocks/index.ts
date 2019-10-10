import { IUser, IRecentFile, IEvent, ITask, ISharedFile, DocumentType, IOnenoteNote } from '../endpoints';

export const getMockedUserData = (): IUser => {
  return {
    mail: 'krzysztof.nofz@makingwaves.com',
    givenName: 'Krzysztof',
    mobilePhone: '+48882433272',
  };
};

export const getMockedUserEvents = (): IEvent[] => {
  return [
    {
      id: '1',
      date: '01/10/2019',
      toStart: 15,
      subject: 'Standup SATS',
      webLink: 'https://onet.pl',
      endHour: '10:00',
      startHour: '09:00',
      locationName: 'Room KRA - 1/1 (Video, 8 pers)',
    },
    {
      id: '2',
      date: '02/10/2019',
      subject: 'Standup MatPrat',
      webLink: 'https://onet.pl',
      endHour: '12:00',
      startHour: '11:00',
      locationName: 'Room KRA - 1/2 (Video, 8 pers)',
    },
    {
      id: '3',
      date: '04/10/2019',
      subject: 'Employee meeting',
      webLink: 'https://onet.pl',
      endHour: '08:00',
      startHour: '08:30',
      locationName: 'Room KRA - 3/2 (Video, 8 pers)',
    },
  ];
};

export const getMockedUserTasks = (): ITask[] => {
  return [
    {
      id: '1',
      title: 'Send a meeting summary to a client',
      dueToDate: 'Friday, May 31, 2019',
      isCompleted: true,
    },
    {
      id: '2',
      title: 'Create an agenda for upcoming EM',
      dueToDate: 'Friday, May 31, 2020',
      isCompleted: false,
    },
    {
      id: '3',
      title: 'Set a meeting with Dorota Klimek',
      dueToDate: 'Friday, May 31, 2019',
      isCompleted: false,
    },
    {
      id: '4',
      title: 'Set a meeting with Krzysztof Nofz',
      dueToDate: 'Friday, May 31, 2019',
      isCompleted: false,
    },
  ];
};

export const getMockedSharedFiles = (): ISharedFile[] => {
  return [
    {
      id: '1',
      name: 'Modern Intranet Platform.xlsx',
      type: DocumentType.Excel,
      webUrl: 'https://onet.pl',
      sharedBy: 'Łukasz Wilisowski',
    },
    {
      id: '2',
      name: 'Offer Design Estimation.doc',
      type: DocumentType.Word,
      webUrl: 'https://onet.pl',
      sharedBy: 'Krzysztof Nofz',
    },
    {
      id: '3',
      name: 'Design for good or evil.pptx',
      type: DocumentType.PowerPoint,
      webUrl: 'https://onet.pl',
      sharedBy: 'Magdalena Ruta',
    },
  ];
};

export const getMockedRecentlyOpenedFiles = (): IRecentFile[] => {
  return [
    {
      id: '1',
      name: 'WHO_Offer.docx',
      type: DocumentType.Word,
      webUrl: 'https://onet.pl',
      updatedBy: 'Kamelia Niemczyk',
      lastUpdate: '20/04/2019',
    },
    {
      id: '2',
      name: 'Offer_Valg.pptx',
      type: DocumentType.PowerPoint,
      webUrl: 'https://onet.pl',
      updatedBy: 'Krzysztof Nofz',
      lastUpdate: '20/05/2019',
    },
    {
      id: '3',
      name: 'Estimation_WHO.xlsx',
      type: DocumentType.Excel,
      webUrl: 'https://onet.pl',
      updatedBy: 'Magdalena Ruta',
      lastUpdate: '01/10/2019',
    },
  ];
};

export const getMockedOnenotePages = (): IOnenoteNote[] => {
  return [
    {
      id: '1',
      name: 'Meeting Summary MatPrat 23.09',
      webUrl: 'https://onet.pl',
    },
    {
      id: '2',
      name: 'Meeting Summary MatPrat 10.10',
      webUrl: 'https://onet.pl',
    },
    {
      id: '3',
      name: 'Meeting Summary Sats 22.03',
      webUrl: 'https://onet.pl',
    },
    {
      id: '4',
      name: 'Retro 31.08 - actions points',
      webUrl: 'https://onet.pl',
    },
  ];
};

export const getMocedOnenoteSections = (): IOnenoteNote[] => {
  return [
    {
      id: '1a',
      name: 'BFM Workshop',
      webUrl: 'https://onet.pl',
    },
    {
      id: '2a',
      name: 'Design Teams Status 2019',
      webUrl: 'https://onet.pl',
    },
    {
      id: '3a',
      name: 'Design Teams Status 2018',
      webUrl: 'https://onet.pl',
    },
    {
      id: '4a',
      name: 'Innovation Jam - ideas',
      webUrl: 'https://onet.pl',
    },
  ];
};
