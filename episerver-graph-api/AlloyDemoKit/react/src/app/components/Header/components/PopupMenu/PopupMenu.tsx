import classNames from 'classnames';
import React, { FunctionComponent, useState } from 'react';

import Styles from './PopupMenu.module.scss';

import Popup from './components/Popup';
import Button from 'common/components/Button';
import LazyImage from 'common/components/LazyImage';

type PopupMenuProps = {
  userPhotoUrl: string;
  userFullName: string;
};

const PopupMenu: FunctionComponent<PopupMenuProps> = ({ userPhotoUrl, userFullName }) => {
  const [showPopup, setShowPopup] = useState<boolean>(false);

  const togglePopup = (): void => {
    setShowPopup(!showPopup);
  };

  return (
    <div className={classNames(Styles.container, 'flex items-center relative')}>
      <LazyImage source={userPhotoUrl} alt={'Your photo'} imageClass={Styles.image} />
      <Button onClick={togglePopup}>
        <div className={'flex items-center ml-sm'}>
          <p className={classNames('mr-mini', Styles.userName)}>{userFullName}</p>
          <svg
            className={classNames(Styles.svg, { [Styles.popupShown]: showPopup })}
            xmlns="http://www.w3.org/2000/svg"
            width="24"
            height="24"
            viewBox="0 0 24 24"
          >
            <path d="M7.41 8.59L12 13.17l4.59-4.58L18 10l-6 6-6-6 1.41-1.41z" />
            <path fill="none" d="M0 0h24v24H0V0z" />
          </svg>
        </div>
      </Button>
      <Popup isVisible={showPopup} />
    </div>
  );
};

export default PopupMenu;
