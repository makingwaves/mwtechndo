import classNames from 'classnames';
import React, { useEffect, FunctionComponent, memo } from 'react';

import Styles from './Error.module.scss';

type ErrorProps = {
  msg: string;
  onMessageClear: () => void;
};

const Error: FunctionComponent<ErrorProps> = ({ msg, onMessageClear }) => {
  let timeoutFn: ReturnType<typeof setTimeout>;

  useEffect(() => {
    if (!!msg) {
      timeoutFn = setTimeout(() => {
        onMessageClear();
      }, 3000);
    }
    return (): void => {
      if (timeoutFn) {
        clearTimeout(timeoutFn);
      }
    };
  }, [msg]);

  return (
    <div className={classNames(Styles.container, 'aspect-ratio--object pvt-md pht-sm')}>
      <p className={classNames(Styles.message, 'm-reset tc')}>{msg}</p>
    </div>
  );
};

export default memo(Error);
