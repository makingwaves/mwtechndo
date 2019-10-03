import classNames from 'classnames';
import React, { FunctionComponent, MouseEvent } from 'react';

import Styles from './SquareArrow.module.scss';

import Button from 'common/components/Button';

type SquareArrowProps = {
  onClick: (e: MouseEvent<HTMLElement>) => void;
};

const SquareArrow: FunctionComponent<SquareArrowProps> = ({ onClick }) => {
  return (
    <Button onClick={onClick} buttonClass={classNames(Styles.container, 'absolute right-0 top-0 p-mini')}>
      <svg className={Styles.svg} xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24">
        <path d="M0 0h24v24H0z" fill="none" />
        <path d="M12 4l-1.41 1.41L16.17 11H4v2h12.17l-5.58 5.59L12 20l8-8z" />
      </svg>
    </Button>
  );
};

export default SquareArrow;
