import classNames from 'classnames';
import React, { FunctionComponent, useState, useEffect } from 'react';

import Styles from './AccountBlock.module.scss';

import { IUser, getUserData } from 'common/api';

import UserInformation from './components/UserInformation/UserInformation';
import ContentPlaceholder from 'common/components/ContentPlaceholder';

type AccountBlockProps = {};

const AccountBlock: FunctionComponent<AccountBlockProps> = () => {
  const [loading, setLoading] = useState<boolean>(true);
  const [user, setUser] = useState<IUser>({} as IUser);

  useEffect(() => {
    const fetchUserData = async (): Promise<void> => {
      const user = await getUserData();
      setUser(user);
      setLoading(false);
    };
    fetchUserData();
  }, []);

  return (
    <div className={classNames('block', Styles.container)}>
      <ContentPlaceholder showContent={!loading}>
        <UserInformation {...user} />
      </ContentPlaceholder>
    </div>
  );
};

export default AccountBlock;
