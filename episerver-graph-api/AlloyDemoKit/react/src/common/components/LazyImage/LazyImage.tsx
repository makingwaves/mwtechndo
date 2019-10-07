import classNames from 'classnames';
import React, { FunctionComponent, useState, useEffect, useRef } from 'react';

import Styles from './LazyImage.module.scss';

import { loadImage } from 'common/utils';

import Spinner from '../Spinner';

type LazyImageProps = {
  alt: string;
  source: string;
  imageClass?: string;
  containerClass?: string;
};

const LazyImage: FunctionComponent<LazyImageProps> = ({ alt, source, containerClass = '', imageClass = '' }) => {
  const imgRef = useRef<HTMLImageElement>(null);
  const [loading, setLoading] = useState<boolean>(true);

  useEffect(() => {
    if (!!source && imgRef.current) {
      const onComplete = (): void => {
        setLoading(false);
      };
      const onError = (): void => {
        setLoading(false);
      };
      setLoading(true);
      loadImage(imgRef.current, onComplete, onError);
    }
  }, [source]);

  return (
    <div className={classNames(containerClass, 'flex items-center justify-center h-100')}>
      {loading && <Spinner containerClass={Styles.spinner} />}
      <img ref={imgRef} src={source} alt={alt} className={imageClass} />
    </div>
  );
};

export default LazyImage;
