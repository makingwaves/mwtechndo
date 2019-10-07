import React, { FunctionComponent, useState, useEffect } from 'react';

import { IOnenoteNote, getOnenoteNotes, IContent } from 'common/api';

import NotesContainer from './components/NotesContainer';
import ContentPlaceholder from 'common/components/ContentPlaceholder';

type NotesBlockProps = IContent;

const NotesBlock: FunctionComponent<NotesBlockProps> = () => {
  const [loading, setLoading] = useState<boolean>(true);
  const [notes, setNotes] = useState<IOnenoteNote[]>([]);

  useEffect(() => {
    const fetchLinks = async (): Promise<void> => {
      const links = await getOnenoteNotes();
      setLoading(false);
      setNotes(links);
    };
    fetchLinks();
  }, []);

  return (
    <div className={'block relative'}>
      <ContentPlaceholder showContent={!loading}>
        <NotesContainer notes={notes} />
      </ContentPlaceholder>
    </div>
  );
};

export default NotesBlock;
