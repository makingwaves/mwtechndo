import React, { FunctionComponent, MouseEvent } from 'react';

import { IEvent } from 'common/api';

import Event from './components/Event';
import SquareArrow from 'common/components/SquareArrow';

type EventsContainerProps = {
  events: IEvent[];
};

const EventsContainer: FunctionComponent<EventsContainerProps> = ({ events }) => {
  const onArrowClick = (e: MouseEvent<HTMLElement>): void => {};

  return (
    <section>
      <SquareArrow onClick={onArrowClick} />
      <h2 className={'mt-reset mb-lg title-block'}>Upcoming events</h2>
      {events.map(e => (
        <Event key={e.id} {...e} />
      ))}
    </section>
  );
};

export default EventsContainer;
