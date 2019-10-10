import React, { FunctionComponent, useState, useEffect, ChangeEvent, useCallback } from 'react';

import { getAxiosError } from 'common/utils';
import { ITask, getUserTasks, IContent, completeTask } from 'common/api';

import Error from 'common/components/Error';
import BlockLoader from 'common/components/BlockLoader';
import TasksContainer from './components/TasksContainer';
import ContentPlaceholder from 'common/components/ContentPlaceholder';

type TaskBlockProps = IContent;

const TaskBlock: FunctionComponent<TaskBlockProps> = props => {
  const [error, setError] = useState<string>('');
  const [tasks, setTasks] = useState<ITask[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [blockLoader, setBlockLoader] = useState<boolean>(false);

  const clearErrorMessage = useCallback(() => {
    setError('');
  }, []);

  const onTaskChange = useCallback(async ({ currentTarget: { id } }: ChangeEvent<HTMLInputElement>): Promise<void> => {
    try {
      setBlockLoader(true);
      const x = await completeTask(id);
    } catch (e) {
      setBlockLoader(false);
      setError(getAxiosError(e));
    }
  }, []);

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
      {error && <Error msg={error} onMessageClear={clearErrorMessage} />}
      <ContentPlaceholder showContent={!loading}>
        <TasksContainer tasks={tasks} content={props} onTaskChange={onTaskChange} />
      </ContentPlaceholder>
    </div>
  );
};

export default TaskBlock;
