import classNames from 'classnames';
import React, { FunctionComponent, MouseEvent, memo, ReactElement } from 'react';

import Styles from './Button.module.scss';

type ButtonProps = {
  onClick: (e: MouseEvent<HTMLButtonElement>) => void;
  children: ReactElement;
  buttonClass?: string;
};

const Button: FunctionComponent<ButtonProps> = ({ children, onClick, buttonClass = '' }) => {
  return (
    <button className={classNames(buttonClass, Styles.button, 'pointer')} onClick={onClick} type={'button'}>
      {children}
    </button>
  );
};

export default memo(Button);
