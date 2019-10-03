import classNames from 'classnames';
import React, { FunctionComponent, memo, useState, useEffect } from 'react';

import Styles from './Header.module.scss';

import { getHeaderData, IGeneralUser } from 'common/api';

import Search from './components/Search';
import PopupMenu from './components/PopupMenu';
import LazyImage from 'common/components/LazyImage';

type HeaderProps = {};

const Header: FunctionComponent<HeaderProps> = () => {
  const [logoUrl, setLogoUrl] = useState<string>('');
  const [user, setUser] = useState<IGeneralUser>({} as IGeneralUser);

  useEffect(() => {
    const fetchHeaderData = async (): Promise<void> => {
      const { logoUrl, userFullName, userPhotoUrl } = await getHeaderData();
      setLogoUrl(logoUrl);
      setUser({ userFullName, userPhotoUrl });
    };
    fetchHeaderData();
  }, []);

  return (
    <header className={classNames(Styles.header, 'flex justify-between mvt-lg')}>
      <h1 className={'m-reset'}>
        <LazyImage source={logoUrl} alt={'Company logo'} containerClass={Styles.image} />
      </h1>
      <div className={classNames(Styles.container, 'flex flex-column items-end')}>
        <Search />
        <PopupMenu {...user} />
      </div>
    </header>
  );
};

export default memo(Header);
