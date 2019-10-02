import classNames from 'classnames';
import React, { FunctionComponent, memo, ChangeEvent, ReactElement } from 'react';

import Styles from './Checkbox.module.scss';

type CheckboxProps = {
  id: string;
  checked: boolean;
  onChange: (e: ChangeEvent<HTMLInputElement>) => void;
  children: ReactElement;
};

const Checkbox: FunctionComponent<CheckboxProps> = ({ id, checked, onChange, children }) => {
  return (
    <div className={'relative'}>
      <label className={'flex pointer'} htmlFor={id}>
        <div
          className={classNames('flex items-center justify-center mr-sm', Styles.mark, { [Styles.checked]: checked })}
        />
        <input className={'hidden-block'} id={id} type={'checkbox'} checked={checked} onChange={onChange} />
        {children}
      </label>
    </div>
  );
};

export default memo(Checkbox);
