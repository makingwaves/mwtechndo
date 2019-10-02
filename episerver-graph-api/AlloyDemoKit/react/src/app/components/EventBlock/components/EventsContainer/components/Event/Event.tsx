import classNames from 'classnames';
import React, { FunctionComponent } from 'react';

import Styles from './Event.module.scss';

import { IEvent } from 'common/api';

type EventProps = IEvent;

const Event: FunctionComponent<EventProps> = ({ toStart, date, endHour, startHour, locationName, subject }) => {
  return (
    <div>
      <h3 className={classNames('item-title flex items-center flex-wrap mb-reset mt-lg')}>
        <strong className={'mr-md'}>{subject}</strong>
        {toStart && <div className={classNames(Styles.toStartBox, 'ttu')}>in {toStart} minutes</div>}
      </h3>
      <div className={classNames(Styles.eventContainer, 'flex flex-column')}>
        <span className={Styles.item}>{date}</span>
        <span className={Styles.item}>
          {startHour} - {endHour}
        </span>
        <span className={Styles.item}>{locationName}</span>
      </div>
    </div>
  );
};

export default Event;
