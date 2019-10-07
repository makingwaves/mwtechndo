import React, { FunctionComponent, useEffect, useState } from 'react';

import ContentPlaceholder from 'common/components/ContentPlaceholder';
import SharedFilesContainer from './components/SharedFilesContainer';

import { ISharedFile, getUserSharedFiles, IContent } from 'common/api';

type SharedFilesBlockProps = IContent;

const SharedFilesBlock: FunctionComponent<SharedFilesBlockProps> = () => {
  const [loading, setLoading] = useState<boolean>(true);
  const [sharedFiles, setSharedFiles] = useState<ISharedFile[]>([]);

  useEffect(() => {
    const fetchSharedFiles = async (): Promise<void> => {
      const sharedFiles = await getUserSharedFiles();
      setSharedFiles(sharedFiles);
      setLoading(false);
    };
    fetchSharedFiles();
  }, []);

  return (
    <div className={'block relative'}>
      <ContentPlaceholder showContent={!loading}>
        <SharedFilesContainer files={sharedFiles} />
      </ContentPlaceholder>
    </div>
  );
};

export default SharedFilesBlock;
