import classNames from 'classnames';
import React, { FunctionComponent, MouseEvent } from 'react';

import { ITask } from 'common/api';

import Task from './components/Task';
import SquareArrow from 'common/components/SquareArrow/SquareArrow';

type TasksContainerProps = {
  tasks: ITask[];
};

const TasksContainer: FunctionComponent<TasksContainerProps> = ({ tasks }) => {
  const onArrowClick = (e: MouseEvent<HTMLElement>): void => {};

  return (
    <section>
      <SquareArrow onClick={onArrowClick} />
      <h2 className={classNames('mt-reset mb-lg title-block')}>Upcoming tasks</h2>
      {tasks.map(t => (
        <Task key={t.id} {...t} />
      ))}
    </section>
  );
};

export default TasksContainer;
