import React, { FunctionComponent, memo } from 'react';

import { DocumentType } from 'common/api';

import Word from './components/Word';
import Excel from './components/Excel';
import Powerpoint from './components/Powerpoint';

type DocumentImageProps = {
  type: DocumentType;
  svgClass?: string;
};

const DocumentImage: FunctionComponent<DocumentImageProps> = ({ type, svgClass }) => {
  if (type === DocumentType.Word) {
    return <Word svgClass={svgClass} />;
  }
  if (type === DocumentType.Excel) {
    return <Excel svgClass={svgClass} />;
  }
  if (type === DocumentType.PowerPoint) {
    return <Powerpoint svgClass={svgClass} />;
  }
  return null;
};

export default memo(DocumentImage);
