import React, { FunctionComponent } from 'react';

import Styles from './Note.module.scss';

import { IOnenoteNote } from 'common/api';
import classNames from 'classnames';

type NoteProps = IOnenoteNote;

const Note: FunctionComponent<NoteProps> = ({ name, webUrl }) => {
  return (
    <a className={'no-underline'} href={webUrl}>
      <section className={'mt-md flex items-center'}>
        <svg
          className={'mr-sm'}
          xmlns="http://www.w3.org/2000/svg"
          width="25"
          height="25"
          fill="none"
          viewBox="0 0 25 25"
        >
          <path stroke="#000" strokeLinejoin="round" d="M16 16v8H1V1h23v15h-8z" clipRule="evenodd" />
          <path stroke="#000" strokeLinejoin="round" d="M24 16l-8 8" />
          <path
            stroke="#000"
            strokeLinecap="round"
            strokeLinejoin="round"
            d="M5.5 10.5l1-1a1.415 1.415 0 012 0 1.415 1.415 0 002 0 1.415 1.415 0 012 0 1.415 1.415 0 002 0 1.415 1.415 0 012 0 1.415 1.415 0 002 0l1-1M5.5 15.5l1-1a1.415 1.415 0 012 0 1.415 1.415 0 002 0"
          />
        </svg>
        <h3 className={classNames(Styles.name, 'fw4')}>{name}</h3>
      </section>
    </a>
  );
};

export default Note;
