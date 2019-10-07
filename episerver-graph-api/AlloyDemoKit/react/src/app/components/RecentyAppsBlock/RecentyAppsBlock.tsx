import React, { useState, useEffect, FunctionComponent } from 'react';

import { IContent, IRecentlyApps, getRecentlyUsedApps } from 'common/api';

import ContentPlaceholder from 'common/components/ContentPlaceholder';
import RecentlyAppsContainer from './components/RecentlyAppsContainer';

type RecentyAppsBlockProps = IContent;

const RecentyAppsBlock: FunctionComponent<RecentyAppsBlockProps> = props => {
  const [apps, setApps] = useState<IRecentlyApps[]>([]);
  const [loading, setLoading] = useState<boolean>(true);

  useEffect(() => {
    const fetchFiles = async (): Promise<void> => {
      const apps = await getRecentlyUsedApps();
      setLoading(false);
      setApps(apps);
    };
    fetchFiles();
  }, []);

  return (
    <div className={'block relative'}>
      <ContentPlaceholder showContent={!loading}>
        <RecentlyAppsContainer content={props} apps={apps} />
      </ContentPlaceholder>
    </div>
  );
};

export default RecentyAppsBlock;
