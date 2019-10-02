import classNames from 'classnames';
import React, { FunctionComponent } from 'react';

import Styles from './SharedFile.module.scss';

import { ISharedFile } from 'common/api';

import DocumentImage from 'common/components/DocumentImage';

type SharedFileProps = ISharedFile;

const SharedFile: FunctionComponent<SharedFileProps> = ({ type, name, sharedBy }) => {
  return (
    <div className={'mb-md flex'}>
      <DocumentImage svgClass={classNames(Styles.svg, 'mr-sm')} type={type} />
      <section>
        <h3 className={'item-title m-reset'}>{name}</h3>
        <p className={classNames(Styles.shared, 'm-reset')}>Shared by {sharedBy}</p>
      </section>
    </div>
  );
};

export default SharedFile;
