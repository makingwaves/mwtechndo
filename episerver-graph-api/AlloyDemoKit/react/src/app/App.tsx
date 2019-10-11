import React, { FunctionComponent, useState, useEffect } from 'react';

import Styles from './App.module.scss';

import { getContent, IContent } from 'common/api';

import Header from './components/Header';
import Footer from './components/Footer';
import Spinner from 'common/components/Spinner';
import DynamicComponents from './components/DynamicComponents';
import classNames from 'classnames';

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
    <div className={'relative'}>
      <div className={classNames(Styles.imageContainer, 'absolute left-0 top-0')}>
        <svg viewBox="0 0 100 100" preserveAspectRatio="xMinYMin">
          <defs>
            <clipPath id="svgLogoBuble" clipPathUnits="objectBoundingBox">
              <path
                d="m 0 0 l 0.85 0 c 0.10 0.10 0.11 0.35 0.10 0.40 c -0.01 0.10 -0.10 0.20 -0.10 0.20 c -0.05 0.05 -0.10 0.20 -0.10 0.20 c -0.05 0.20 -0.15 0.20 -0.30 0.20 c -0.10 0 -0.20 -0.05 -0.25 -0.05 c -0.10 -0.01 -0.15 0 -0.20 0.05"
                stroke="#000000"
                strokeWidth="1"
              />
            </clipPath>
          </defs>
        </svg>
      </div>
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
