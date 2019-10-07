import React, { FunctionComponent, useState, useEffect } from 'react';

import { getUserEvents, IEvent, IContent } from 'common/api';

import EventsContainer from './components/EventsContainer';
import ContentPlaceholder from 'common/components/ContentPlaceholder';

type EventBlockProps = IContent;

const EventBlock: FunctionComponent<EventBlockProps> = () => {
  const [loading, setLoading] = useState<boolean>(true);
  const [events, setEvents] = useState<IEvent[]>([]);

  useEffect(() => {
    const fetchUserEvents = async (): Promise<void> => {
      const user = await getUserEvents();
      setEvents(user);
      setLoading(false);
    };
    fetchUserEvents();
  }, []);

  return (
    <div className={'block relative'}>
      <ContentPlaceholder showContent={!loading}>
        <EventsContainer events={events} />
      </ContentPlaceholder>
    </div>
  );
};

export default EventBlock;
