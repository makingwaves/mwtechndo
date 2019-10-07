import Microlink from '@microlink/react';
import React, { FunctionComponent } from 'react';

import { IContent } from 'common/api';

type PosterBlockProps = IContent;

const PosterBlock: FunctionComponent<PosterBlockProps> = ({ url }) => {
  if (url) {
    return (
      <div className={'block p-reset'}>
        <Microlink url={url} size={'large'} />
      </div>
    );
  }
  return null;
};

export default PosterBlock;
