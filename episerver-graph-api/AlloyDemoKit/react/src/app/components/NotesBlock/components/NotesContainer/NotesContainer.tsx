import React, { FunctionComponent, MouseEvent } from 'react';

import { IOnenoteNote } from 'common/api';

import Note from './components/Note';
import SquareArrow from 'common/components/SquareArrow';

type NotesContainerProps = {
  notes: IOnenoteNote[];
};

const NotesContainer: FunctionComponent<NotesContainerProps> = ({ notes }) => {
  const onArrowClick = (e: MouseEvent<HTMLElement>): void => {};

  return (
    <section>
      <SquareArrow onClick={onArrowClick} />
      <h2 className={'mt-reset mb-lg title-block'}>My notes</h2>
      {notes.map(n => (
        <Note key={n.id} {...n} />
      ))}
    </section>
  );
};

export default NotesContainer;
