import React, { FunctionComponent } from 'react';

import { IContent, IRecentlyApps } from 'common/api';

import RecentlyApp from './components/RecentlyApp';

type RecentlyAppsContainerProps = {
  apps: IRecentlyApps[];
  content: IContent;
};

const RecentlyAppsContainer: FunctionComponent<RecentlyAppsContainerProps> = ({ apps, content }) => {
  return (
    <section>
      <h2 className={'mt-reset mb-lg title-block'}>{content.title}</h2>
      {apps.map(a => (
        <RecentlyApp key={a.id} {...a} />
      ))}
    </section>
  );
};

export default RecentlyAppsContainer;
