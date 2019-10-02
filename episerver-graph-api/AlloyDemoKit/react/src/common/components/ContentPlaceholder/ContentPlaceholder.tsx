import React, { Fragment, ComponentType, FunctionComponent } from 'react';

type ContentPlaceholderProps = {
  showContent: boolean;
  placeholder?: ComponentType;
};

const ContentPlaceholder: FunctionComponent<ContentPlaceholderProps> = ({ children, showContent, placeholder }) => {
  const Placeholder = placeholder ? placeholder : <div>Wczytuje</div>;

  return <Fragment>{showContent ? children : Placeholder}</Fragment>;
};

export default ContentPlaceholder;
