import classNames from 'classnames';
import React, { FunctionComponent, ChangeEvent } from 'react';

import Styles from './Input.module.scss';

type InputProps = {
  id: string;
  value: string;
  label: string;
  onChange: (e: ChangeEvent<HTMLInputElement>) => void;
  containerClass?: string;
};

const Input: FunctionComponent<InputProps> = ({ id, value, label, onChange, containerClass = '' }) => {
  return (
    <div className={classNames(containerClass, Styles.container, 'relative flex')}>
      <input id={id} value={value} onChange={onChange} className={classNames(Styles.input, 'pvt-mini pht-sm')} />
      <label htmlFor={id} className={classNames(Styles.label, 'absolute', { [Styles.filled]: !!value })}>
        {label}
      </label>
    </div>
  );
};

export default Input;
