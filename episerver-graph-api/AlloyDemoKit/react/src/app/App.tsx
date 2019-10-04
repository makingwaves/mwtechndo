import React, { FunctionComponent } from 'react';

import Styles from './App.module.scss';

import { getIntranetBlocks } from 'common/api';

import Header from './components/Header';
import Footer from './components/Footer';
import DynamicComponents from './components/DynamicComponents';

type AppProps = {};

const blocks = getIntranetBlocks();

const App: FunctionComponent<AppProps> = () => {
  return (
    <div>
      <div className={'page-container'}>
        <Header />
        <main className={Styles.main}>
          {blocks.map(b => (
            <DynamicComponents key={b} componentKey={b} />
          ))}
        </main>
      </div>
      <Footer />
    </div>
  );
};

export default App;
