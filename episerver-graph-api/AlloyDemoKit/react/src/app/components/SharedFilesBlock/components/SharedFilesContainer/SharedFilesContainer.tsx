import classNames from 'classnames';
import React, { FunctionComponent, MouseEvent } from 'react';

import { ISharedFile } from 'common/api';

import SharedFile from './components/SharedFile';
import SquareArrow from 'common/components/SquareArrow';

type SharedFilesContainerProps = {
  files: ISharedFile[];
};

const SharedFilesContainer: FunctionComponent<SharedFilesContainerProps> = ({ files }) => {
  const onArrowClick = (e: MouseEvent<HTMLElement>): void => {};

  return (
    <section>
      <SquareArrow onClick={onArrowClick} />
      <h2 className={classNames('mt-reset mb-lg title-block')}>Files shared with me</h2>
      {files.map(file => (
        <SharedFile key={file.id} {...file} />
      ))}
    </section>
  );
};

export default SharedFilesContainer;
