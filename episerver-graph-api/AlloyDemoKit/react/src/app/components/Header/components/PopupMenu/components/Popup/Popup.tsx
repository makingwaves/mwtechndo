import classNames from 'classnames';
import React, { FunctionComponent, memo, Fragment } from 'react';

import Styles from './Popup.module.scss';

import Button from 'common/components/Button';

type PopupProps = {
  isVisible: boolean;
};

const Popup: FunctionComponent<PopupProps> = ({ isVisible }) => {
  const logout = (): void => {};

  return (
    <aside className={classNames(Styles.aside, { [Styles.shown]: isVisible }, 'absolute left-0 right-0')}>
      <ul className={'list p-reset m-reset tr'}>
        <li className={'p-sm'}>
          <Button onClick={logout}>
            <Fragment>Logout</Fragment>
          </Button>
        </li>
      </ul>
    </aside>
  );
};

export default memo(Popup);
