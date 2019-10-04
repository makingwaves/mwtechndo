import classNames from 'classnames';
import React, { FunctionComponent } from 'react';

import Styles from './Link.module.scss';

import { ILink } from 'common/api';

import LazyImage from 'common/components/LazyImage';

type LinkProps = ILink;

const Link: FunctionComponent<LinkProps> = ({ name, logoUrl }) => {
  return (
    <a href={name} className={'mb-md db'}>
      <section className={'flex items-center'}>
        <LazyImage source={logoUrl} alt={`${name} brand`} imageClass={Styles.image} />
        <h3 className={classNames(Styles.name, 'm-reset ml-sm fw4')}>{name}</h3>
      </section>
    </a>
  );
};

export default Link;
