import React, { Fragment, ComponentType, FunctionComponent } from 'react';

import InitialPlaceholder from './components/InitialPlaceholder';

type ContentPlaceholderProps = {
  showContent: boolean;
  placeholder?: ComponentType;
};

const ContentPlaceholder: FunctionComponent<ContentPlaceholderProps> = ({ children, showContent, placeholder }) => {
  const Placeholder = placeholder ? placeholder : <InitialPlaceholder />;

  return <Fragment>{showContent ? children : Placeholder}</Fragment>;
};

export default ContentPlaceholder;
