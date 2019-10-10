import classNames from 'classnames';
import React, { FunctionComponent } from 'react';

import Styles from './BlockLoader.module.scss';

import Spinner from 'common/components/Spinner';

type BlockLoaderProps = {};

const BlockLoader: FunctionComponent<BlockLoaderProps> = () => {
  return (
    <div className={classNames(Styles.container, 'aspect-ratio--object flex items-center justify-center')}>
      <Spinner containerClass={Styles.spinner} />
    </div>
  );
};

export default BlockLoader;
