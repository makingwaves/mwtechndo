import { IUser, IEvent, ITask, ISharedFile, DocumentType } from '../endpoints';

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
