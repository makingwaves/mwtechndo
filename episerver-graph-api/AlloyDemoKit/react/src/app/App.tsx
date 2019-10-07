import React, { FunctionComponent, useState, useEffect } from 'react';

import Styles from './App.module.scss';

import { getContent, IContent } from 'common/api';

import Header from './components/Header';
import Footer from './components/Footer';
import Spinner from 'common/components/Spinner';
import DynamicComponents from './components/DynamicComponents';

type AppProps = {};

const App: FunctionComponent<AppProps> = () => {
  const [loading, setLoading] = useState<boolean>(true);
  const [content, setContent] = useState<IContent[]>([]);

  useEffect(() => {
    const fetchContent = async (): Promise<void> => {
      const content = await getContent();
      setLoading(false);
      setContent(content);
    };
    fetchContent();
  }, []);

  if (loading) {
    return (
      <div className={'aspect-ratio--object-ns fixed flex items-center justify-center'}>
        <Spinner />
      </div>
    );
  }

  return (
    <div>
      <div className={'page-container'}>
        <Header />
        <main className={Styles.main}>
          {content.map(c => (
            <DynamicComponents key={c.type} componentKey={c.type} ownProps={c} />
          ))}
        </main>
      </div>
      <Footer />
    </div>
  );
};

export default App;
