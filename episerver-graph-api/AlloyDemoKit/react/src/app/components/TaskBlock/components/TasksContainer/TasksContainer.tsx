import classNames from 'classnames';
import React, { FunctionComponent, MouseEvent, ChangeEvent } from 'react';

import { ITask, IContent } from 'common/api';

import Task from './components/Task';
import SquareArrow from 'common/components/SquareArrow/SquareArrow';

type TasksContainerProps = {
  tasks: ITask[];
  content: IContent;
  onTaskChange: (e: ChangeEvent<HTMLInputElement>) => void;
};

const TasksContainer: FunctionComponent<TasksContainerProps> = ({ tasks, onTaskChange, content }) => {
  const onArrowClick = (e: MouseEvent<HTMLElement>): void => {};

  return (
    <section>
      <SquareArrow onClick={onArrowClick} />
      <h2 className={classNames('mt-reset mb-lg title-block')}>{content.title}</h2>
      {tasks.map(t => (
        <Task key={t.id} {...t} onTaskChange={onTaskChange} />
      ))}
    </section>
  );
};

export default TasksContainer;
