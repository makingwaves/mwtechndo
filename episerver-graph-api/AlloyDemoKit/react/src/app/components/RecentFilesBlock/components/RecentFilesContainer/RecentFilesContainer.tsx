import classNames from 'classnames';
import React, { FunctionComponent, MouseEvent } from 'react';

import Styles from './RecentFilesContainer.module.scss';

import { IRecentFile } from 'common/api';

import RecentFile from './components/RecentFile';
import SquareArrow from 'common/components/SquareArrow';

type RecentFilesContainerProps = {
  recentFiles: IRecentFile[];
};

const RecentFilesContainer: FunctionComponent<RecentFilesContainerProps> = ({ recentFiles }) => {
  const onArrowClick = (e: MouseEvent<HTMLElement>): void => {};

  return (
    <section>
      <SquareArrow onClick={onArrowClick} />
      <h2 className={classNames('mt-reset mb-lg title-block')}>Last opened documents</h2>
      <div className={Styles.container}>
        {recentFiles.map(r => (
          <RecentFile key={r.id} {...r} />
        ))}
      </div>
    </section>
  );
};

export default RecentFilesContainer;
