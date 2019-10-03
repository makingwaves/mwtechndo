import classNames from 'classnames';
import React, { FunctionComponent, useState, ChangeEvent } from 'react';

import Styles from './Search.module.scss';

import Input from 'common/components/Input';
import Button from 'common/components/Button';

type SearchProps = {};

const Search: FunctionComponent<SearchProps> = () => {
  const [searchValue, setSearchValue] = useState<string>('');
  const [showSearchField, setShowSearchField] = useState<boolean>(false);

  const onSearchClick = (): void => {
    if (showSearchField) {
    } else {
      setShowSearchField(true);
    }
  };
  const closeSearchField = (): void => {
    setShowSearchField(false);
  };
  const onValueChange = ({ currentTarget: { value } }: ChangeEvent<HTMLInputElement>): void => {
    setSearchValue(value);
  };

  return (
    <div className={'flex'}>
      <Button onClick={onSearchClick}>
        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24">
          <path d="M15.5 14h-.79l-.28-.27C15.41 12.59 16 11.11 16 9.5 16 5.91 13.09 3 9.5 3S3 5.91 3 9.5 5.91 16 9.5 16c1.61 0 3.09-.59 4.23-1.57l.27.28v.79l5 4.99L20.49 19l-4.99-5zm-6 0C7.01 14 5 11.99 5 9.5S7.01 5 9.5 5 14 7.01 14 9.5 11.99 14 9.5 14z" />
          <path d="M0 0h24v24H0z" fill="none" />
        </svg>
      </Button>
      <div className={classNames('flex', Styles.searchContainer, { [Styles.shown]: showSearchField })}>
        <Input value={searchValue} onChange={onValueChange} id={'search'} label={'Search'} />
        <Button onClick={closeSearchField}>
          <svg xmlns="http://www.w3.org/2000/svg" width="18" height="18" viewBox="0 0 24 24">
            <path d="M19 6.41L17.59 5 12 10.59 6.41 5 5 6.41 10.59 12 5 17.59 6.41 19 12 13.41 17.59 19 19 17.59 13.41 12z" />
            <path d="M0 0h24v24H0z" fill="none" />
          </svg>
        </Button>
      </div>
    </div>
  );
};

export default Search;
