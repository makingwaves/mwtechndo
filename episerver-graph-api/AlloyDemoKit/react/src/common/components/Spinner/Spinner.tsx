import classNames from 'classnames';
import React, { FunctionComponent } from 'react';

import Styles from './Spinner.module.scss';

type SpinnerProps = {
  containerClass?: string;
};

const Spinner: FunctionComponent<SpinnerProps> = ({ containerClass = '' }) => {
  return <div className={classNames(Styles.loading, containerClass)} />;
};

export default Spinner;
