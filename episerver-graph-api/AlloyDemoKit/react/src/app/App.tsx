import React, { FunctionComponent } from 'react';

import { getIntranetBlocks } from 'common/api';

import DynamicComponents from './components/DynamicComponents';

type AppProps = {};

const blocks = getIntranetBlocks();

const App: FunctionComponent<AppProps> = () => {
  return (
    <div className={'page-container'}>
      {blocks.map(b => (
        <DynamicComponents key={b} componentKey={b} />
      ))}
    </div>
  )
}

export default App;