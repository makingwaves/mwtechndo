import classNames from 'classnames';
import React, { FunctionComponent, ChangeEvent } from 'react';

import Styles from './Task.module.scss';

import { ITask } from 'common/api';

import Checkbox from 'common/components/Checkbox';

type TaskProps = {
  onTaskChange: (e: ChangeEvent<HTMLInputElement>) => void;
} & ITask;

const Task: FunctionComponent<TaskProps> = ({ id, title, dueToDate, isCompleted, onTaskChange }) => {
  return (
    <div className={'mb-md'}>
      <Checkbox id={id} checked={isCompleted} onChange={onTaskChange}>
        <section className={Styles.section}>
          <h3 className={'item-title m-reset fw6'}>{title}</h3>
          <h4 className={classNames(Styles.subTitle, 'normal m-reset')}>Due {dueToDate}</h4>
        </section>
      </Checkbox>
    </div>
  );
};

export default Task;
