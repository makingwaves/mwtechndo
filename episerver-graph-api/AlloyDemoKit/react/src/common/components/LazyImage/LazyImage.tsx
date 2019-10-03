import classNames from 'classnames';
import React, { FunctionComponent, useState, useEffect, useRef } from 'react';

import Styles from './LazyImage.module.scss';

import { loadImage } from 'common/utils';

type LazyImageProps = {
  alt: string;
  source: string;
  imageClass?: string;
  containerClass?: string;
};

const LazyImage: FunctionComponent<LazyImageProps> = ({ alt, source, containerClass = '', imageClass = '' }) => {
  const imgRef = useRef<HTMLImageElement>(null);
  const [loading, setLoading] = useState<boolean>(false);

  useEffect(() => {
    if (!!source && imgRef.current) {
      const onComplete = (): void => {
        setLoading(false);
      };
      const onError = (): void => {
        console.error('error');
      };
      setLoading(true);
      loadImage(imgRef.current, onComplete, onError);
    }
  }, [source]);

  return (
    <div className={classNames(containerClass, { [Styles.loading]: loading })}>
      <img ref={imgRef} src={source} alt={alt} className={imageClass} />
    </div>
  );
};

export default LazyImage;
