import React, { FunctionComponent, useState, useEffect } from 'react';

import { ITask, getUserTasks } from 'common/api';

import TasksContainer from './components/TasksContainer/TasksContainer';
import ContentPlaceholder from 'common/components/ContentPlaceholder/ContentPlaceholder';

type TaskBlockProps = {};

const TaskBlock: FunctionComponent<TaskBlockProps> = () => {
  const [loading, setLoading] = useState<boolean>(true);
  const [tasks, setTasks] = useState<ITask[]>([]);

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
      <ContentPlaceholder showContent={!loading}>
        <TasksContainer tasks={tasks} />
      </ContentPlaceholder>
    </div>
  );
};

export default TaskBlock;
