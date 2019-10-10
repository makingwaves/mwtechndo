import classNames from 'classnames';
import React, { FunctionComponent } from 'react';

import Styles from './RecentlyApp.module.scss';

import { IRecentlyApps } from 'common/api';

import LazyImage from 'common/components/LazyImage';

type RecentlyAppProps = IRecentlyApps;

const RecentlyApp: FunctionComponent<RecentlyAppProps> = ({ logoUrl, appUrl, displayName }) => {
  return (
    <div className={classNames(Styles.container, 'mb-sm pb-mini')}>
      <a href={appUrl} className={'inline-flex items-center no-underline'}>
        <LazyImage source={logoUrl} alt={displayName} containerClass={classNames(Styles.image, 'mr-sm')} />
        <h3 className={classNames(Styles.linkName, 'fw4 m-reset')}>{displayName}</h3>
      </a>
    </div>
  );
};

export default RecentlyApp;
