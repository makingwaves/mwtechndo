import classNames from 'classnames';
import React, { FunctionComponent } from 'react';

import Styles from './InitialPlaceholder.module.scss';

type InitialPlaceholderProps = {};

const InitialPlaceholder: FunctionComponent<InitialPlaceholderProps> = () => {
  return (
    <div className={classNames(Styles.container, 'relative')}>
      <div className={Styles.placeholder}>
        <div className={classNames(Styles.item, Styles.underTitle, 'absolute')} />
        <div className={classNames(Styles.item, Styles.upToItem, Styles.upFirst, 'absolute')} />
        <div className={classNames(Styles.item, Styles.nextToItem, Styles.nextFirst, 'absolute')} />
        <div className={classNames(Styles.item, Styles.upToItem, Styles.upSecond, 'absolute')} />
        <div className={classNames(Styles.item, Styles.nextToItem, Styles.nextSecond, 'absolute')} />
        <div className={classNames(Styles.item, Styles.upToItem, Styles.upThird, 'absolute')} />
        <div className={classNames(Styles.item, Styles.nextToItem, Styles.nextThird, 'absolute')} />
      </div>
    </div>
  );
};

export default InitialPlaceholder;
