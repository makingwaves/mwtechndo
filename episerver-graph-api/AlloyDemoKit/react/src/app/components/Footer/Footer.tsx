import classNames from 'classnames';
import React, { FunctionComponent, memo, useState, useEffect } from 'react';

import Styles from './Footer.module.scss';

import { IBrand, getBrand, ISocials, getSocials } from 'common/api';

import LazyImage from 'common/components/LazyImage';
import { ReactComponent as FacebookSvg } from './assets/facebook.svg';
import { ReactComponent as InstagramSvg } from './assets/instagram.svg';
import { ReactComponent as LinkedinSvg } from './assets/linkedin.svg';

type FooterProps = {};

const Footer: FunctionComponent<FooterProps> = () => {
  const [brand, setBrand] = useState<IBrand>({} as IBrand);
  const [socials, setSocials] = useState<ISocials>({} as ISocials);

  useEffect(() => {
    const brand = getBrand();
    const socials = getSocials();
    setSocials(socials);
    setBrand(brand); 
  }, []);

  return (
    <footer className={classNames(Styles.footer, 'flex items-end relative')}>
      <svg className={Styles.svg} xmlns="http://www.w3.org/2000/svg" viewBox="0 0 1440 320">
        <path
          fill="#242424"
          d="M0 96l80 10.7c80 10.3 240 32.3 400 32C640 139 800 117 960 112s320 5 400 10.7l80 5.3v192H0z"
        />
      </svg>
      <div className={classNames(Styles.container, 'page-container')}>
        <section className={Styles.section}>
          <LazyImage source={brand.logoUrl} alt={'Brand logo'} containerClass={Styles.image} />
          <h3 className={classNames(Styles.name, 'm-reset fw6')}>{brand.name}</h3>
          <h4 className={classNames(Styles.description, 'm-reset fw4 mb-md')}>{brand.description}</h4>
          <a className={classNames(Styles.policy, 'fw4')} href={brand.policyUrl}>
            Privacy policy
          </a>
        </section>
        <ul className={'list flex p-reset m-reset'}>
          {socials.facebook && (
            <li className={classNames(Styles.item, 'mr-sm')}>
              <a href={socials.facebook}>
                <FacebookSvg />
              </a>
            </li>
          )}
          {socials.instagram && (
            <li className={classNames(Styles.item, 'mr-sm')}>
              <a href={socials.instagram}>
                <InstagramSvg />
              </a>
            </li>
          )}
          {socials.linkedin && (
            <li className={classNames(Styles.item, 'mr-sm')}>
              <a href={socials.linkedin}>
                <LinkedinSvg />
              </a>
            </li>
          )}
        </ul>
      </div>
    </footer>
  );
};

export default memo(Footer);
