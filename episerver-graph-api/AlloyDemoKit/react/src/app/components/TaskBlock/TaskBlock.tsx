import React, { FunctionComponent, useState, useEffect, ChangeEvent } from 'react';

import { ITask, getUserTasks, IContent, completeTask } from 'common/api';

import BlockLoader from 'common/components/BlockLoader';
import TasksContainer from './components/TasksContainer';
import ContentPlaceholder from 'common/components/ContentPlaceholder';

type TaskBlockProps = IContent;

const TaskBlock: FunctionComponent<TaskBlockProps> = props => {
  const [loading, setLoading] = useState<boolean>(true);
  const [blockLoader, setBlockLoader] = useState<boolean>(false);
  const [tasks, setTasks] = useState<ITask[]>([]);

  const onTaskChange = async ({ currentTarget: { id } }: ChangeEvent<HTMLInputElement>): Promise<void> => {
    try {
      setBlockLoader(true);
      const x = await completeTask(id);
    } catch (e) {
      setBlockLoader(false);
    }
  };

  useEffect(() => {
    const fetchTasks = async (): Promise<void> => {
      const tasks = await getUserTasks();
      setLoading(false);
      setTasks(tasks);
    };
    fetchTasks();
  }, []);

  return (
    <div className={'block relative'}>
      {blockLoader && <BlockLoader />}
      <ContentPlaceholder showContent={!loading}>
        <TasksContainer tasks={tasks} content={props} onTaskChange={onTaskChange} />
      </ContentPlaceholder>
    </div>
  );
};

export default TaskBlock;
