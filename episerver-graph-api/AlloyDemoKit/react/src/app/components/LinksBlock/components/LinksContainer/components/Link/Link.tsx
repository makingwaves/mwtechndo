import classNames from 'classnames';
import React, { FunctionComponent } from 'react';

import Styles from './Link.module.scss';

import { ILink } from 'common/api';

import LazyImage from 'common/components/LazyImage';

type LinkProps = ILink;

const Link: FunctionComponent<LinkProps> = ({ name, logoUrl }) => {
  return (
    <div className={'flex items-center mb-md'}>
      <LazyImage source={logoUrl} alt={`${name} brand`} imageClass={Styles.image} />
      <a href={name} className={classNames(Styles.link, 'm-reset ml-sm')}>
        {name}
      </a>
    </div>
  );
};

export default Link;
