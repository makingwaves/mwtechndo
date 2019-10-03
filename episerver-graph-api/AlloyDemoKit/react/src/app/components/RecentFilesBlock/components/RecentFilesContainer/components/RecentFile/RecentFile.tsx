import classNames from 'classnames';
import React, { FunctionComponent } from 'react';

import Styles from './RecentFile.module.scss';

import { IRecentFile } from 'common/api';

import DocumentImage from 'common/components/DocumentImage';

type RecentFileProps = IRecentFile;

const RecentFile: FunctionComponent<RecentFileProps> = ({ name, type, lastUpdate, updatedBy }) => {
  return (
    <div className={classNames(Styles.container, 'mt-lg flex')}>
      <DocumentImage svgClass={classNames(Styles.svg)} type={type} />
      <section className={classNames(Styles.section, 'ml-sm')}>
        <h3 className={classNames(Styles.name, 'item-title m-reset')}>{name}</h3>
        <p className={classNames(Styles.updateText, 'm-reset')}>Last update: {lastUpdate}</p>
        <p className={classNames(Styles.updatedBy, 'm-reset')}>by {updatedBy}</p>
      </section>
    </div>
  );
};

export default RecentFile;
