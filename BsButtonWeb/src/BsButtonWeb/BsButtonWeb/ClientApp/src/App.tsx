import * as React from 'react';
import {useMemo} from 'react';
import {Route, Switch} from 'react-router';
import Layout from './components/Layout';
import Counter from './components/Counter';
import FetchData from './components/FetchData';

import './custom.css';
import {MainLocations, SecondaryLocations} from "./components/ListItems";

export default () => {
  const routes = useMemo(() =>
      [
        ...MainLocations,
        ...SecondaryLocations
      ].map(routeDef =>
        (<Route key={routeDef.route}
                path={routeDef.route}
                component={routeDef.routeComponent}
                {...routeDef.extraRouteProps} />)
      )
    , []);
  return (
    <Layout>
      <Switch>
        {
          routes
        }
        <Route path='/counter' component={Counter}/>
        <Route path='/fetch-data/:startDateIndex?' component={FetchData}/>
      </Switch>
    </Layout>
  );
};
