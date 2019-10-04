import React, { FunctionComponent, useState, useEffect } from 'react';

import { ILink, getLinks } from 'common/api';

import LinksContainer from './components/LinksContainer/LinksContainer';
import ContentPlaceholder from 'common/components/ContentPlaceholder';

type LinksBlockProps = {};

const LinksBlock: FunctionComponent<LinksBlockProps> = ({}) => {
  const [loading, setLoading] = useState<boolean>(true);
  const [links, setLinks] = useState<ILink[]>([]);

  useEffect(() => {
    const fetchLinks = async (): Promise<void> => {
      const links = await getLinks();
      setLoading(false);
      setLinks(links);
    };
    fetchLinks();
  }, []);

  return (
    <div className={'block relative'}>
      <ContentPlaceholder showContent={!loading}>
        <LinksContainer links={links} />
      </ContentPlaceholder>
    </div>
  );
};

export default LinksBlock;
