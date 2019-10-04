import classNames from 'classnames';
import React, { FunctionComponent } from 'react';

import { ILink } from 'common/api';

import Link from './components/Link';

type LinksContainerProps = {
  links: ILink[];
};

const LinksContainer: FunctionComponent<LinksContainerProps> = ({ links }) => {
  return (
    <section>
      <h2 className={classNames('mt-reset mb-lg title-block')}>Useful links</h2>
      {links.map(l => (
        <Link key={l.id} {...l} />
      ))}
    </section>
  );
};

export default LinksContainer;
