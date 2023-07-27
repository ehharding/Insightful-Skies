import './styles.scss';
import AppRoutes from './AppRoutes';
import Layout from './components/Layout';
import React from 'react';
import { Route, Routes } from 'react-router-dom';

/**
 * The main application component, which defines the application's routes (that map URLs to components) as well as well
 * as wrapping the application in a Layout component, providing a more compartmentalized structure to the application.
 *
 * @returns The main application component.
 */
const App = (): React.ReactElement => {
  return (
    <Layout>
      <Routes>
        {AppRoutes.map((route, index): React.JSX.Element => {
          const { element, ...rest } = route;

          return <Route key={index} {...rest} element={element} />;
        })}
      </Routes>
    </Layout>
  );
}

export default App;
