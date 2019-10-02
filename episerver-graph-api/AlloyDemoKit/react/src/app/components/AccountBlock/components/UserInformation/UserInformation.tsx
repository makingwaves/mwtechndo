import classNames from 'classnames';
import React, { FunctionComponent } from 'react';

import Styles from './UserInformation.module.scss';

import { IUser } from 'common/api';

type UserInformationProps = {} & IUser;

const mailSvg = (
  <svg className={'mr-mini'} width="24" height="24" xmlns="http://www.w3.org/2000/svg">
    <path fill="none" d="M0 0h24v24H0z" />
    <path d="M20 4H4c-1.1 0-1.99.9-1.99 2L2 18c0 1.1.9 2 2 2h16c1.1 0 2-.9 2-2V6c0-1.1-.9-2-2-2zm0 14H4V8l8 5 8-5v10zm-8-7L4 6h16l-8 5z" />
  </svg>
);

const mobilePhoneSvg = (
  <svg className={'mr-mini'} xmlns="http://www.w3.org/2000/svg" width="24" height="24">
    <path d="M16 1H8C6.34 1 5 2.34 5 4v16c0 1.66 1.34 3 3 3h8c1.66 0 3-1.34 3-3V4c0-1.66-1.34-3-3-3zm-2 20h-4v-1h4v1zm3.25-3H6.75V4h10.5v14z" />
    <path d="M0 0h24v24H0z" fill="none" />
  </svg>
);

const UserInformation: FunctionComponent<UserInformationProps> = ({ givenName, mail, mobilePhone }) => {
  return (
    <section className={Styles.container}>
      <h2 className={classNames(Styles.userInfo, 'm-reset')}>Hi {givenName}!</h2>
      <p className={classNames(Styles.info, 'mb-reset')}>Let's get things done!</p>
      <div className={'flex items-center flex-wrap mvt-md'}>
        {mailSvg}
        <span>{mail}</span>
      </div>
      <div className={'flex items-center flex-wrap'}>
        {mobilePhoneSvg}
        <span>{mobilePhone}</span>
      </div>
    </section>
  );
};

export default UserInformation;
