import classNames from 'classnames';
import React, { FunctionComponent, useEffect, useState } from 'react';

import Styles from './RecentFilesBlock.module.scss';

import { IRecentFile, getUserRecentOpenedFiles } from 'common/api';

import ContentPlaceholder from 'common/components/ContentPlaceholder';
import RecentFilesContainer from './components/RecentFilesContainer';

type RecentFilesBlockProps = {};

const RecentFilesBlock: FunctionComponent<RecentFilesBlockProps> = ({}) => {
  const [loading, setLoading] = useState<boolean>(true);
  const [recentFiles, setRecentFiles] = useState<IRecentFile[]>([]);

  useEffect(() => {
    const fetchUserData = async (): Promise<void> => {
      const recentFiles = await getUserRecentOpenedFiles();
      setLoading(false);
      setRecentFiles(recentFiles);
    };
    fetchUserData();
  }, []);

  return (
    <div className={classNames(Styles.container, 'block relative')}>
      <ContentPlaceholder showContent={!loading}>
        <RecentFilesContainer recentFiles={recentFiles} />
      </ContentPlaceholder>
    </div>
  );
};

export default RecentFilesBlock;
