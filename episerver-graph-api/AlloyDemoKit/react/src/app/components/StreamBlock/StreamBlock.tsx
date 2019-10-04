import classNames from 'classnames';
import React, { FunctionComponent, memo } from 'react';

import Styles from './StreamBlock.module.scss';

type StreamBlockProps = {};

const StreamBlock: FunctionComponent<StreamBlockProps> = () => {
  return (
    <div className={classNames(Styles.container, 'block')}>
      <div className={'aspect-ratio overflow-hidden aspect-ratio--16x9'}>
        <iframe
          src="https://web.microsoftstream.com/embed/video/7546b149-fc4c-41a1-9c13-83010c27eb7e?autoplay=false&amp;showinfo=true"
          title={'Microsoft stream'}
          className={classNames(Styles.iframe, 'aspect-ratio--object')}
          allowFullScreen={true}
        />
      </div>
    </div>
  );
};

export default memo(StreamBlock);
