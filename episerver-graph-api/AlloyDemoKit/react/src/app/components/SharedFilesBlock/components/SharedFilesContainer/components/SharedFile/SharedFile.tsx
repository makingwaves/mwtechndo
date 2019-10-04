import classNames from 'classnames';
import React, { FunctionComponent } from 'react';

import Styles from './SharedFile.module.scss';

import { ISharedFile } from 'common/api';

import DocumentImage from 'common/components/DocumentImage';

type SharedFileProps = ISharedFile;

const SharedFile: FunctionComponent<SharedFileProps> = ({ type, name, sharedBy, webUrl }) => {
  return (
    <a href={webUrl} className={'mb-md flex no-underline'}>
      <DocumentImage svgClass={classNames(Styles.svg, 'mr-sm')} type={type} />
      <section className={Styles.section}>
        <h3 className={'item-title m-reset'}>{name}</h3>
        <p className={classNames(Styles.shared, 'm-reset')}>Shared by {sharedBy}</p>
      </section>
    </a>
  );
};

export default SharedFile;
