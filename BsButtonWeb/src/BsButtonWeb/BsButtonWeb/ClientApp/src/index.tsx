import 'bootstrap/dist/css/bootstrap.css';

import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { ConnectedRouter } from 'connected-react-router';
import { createBrowserHistory } from 'history';
import configureStore from './store/configureStore';
import App from './App';
import registerServiceWorker from './registerServiceWorker';
import {createMuiTheme, ThemeProvider} from '@material-ui/core';

const theme = createMuiTheme({
  props: {
    MuiButtonBase: {
      disableRipple: true,
    }
  },
  palette: {
    type: "dark",
    primary: {
      main: '#1b191a',
      contrastText: "#bbbbbb"
    },
    secondary: {
      main: '#4c9697'
    },
    background: {
      paper: "#161415",
      default: "#191718"
    },
    text: {
      primary: "#bbb",
      secondary: "#86a4ab",
      disabled: "#6f6f6f",
    },
    divider: "#211e1e",
    action: {
      hover: "#251719",
      focus: "#251719",
      selected: "#251719"
    }
  },
});

// Create browser history to use in the Redux store
const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href') as string;
const history = createBrowserHistory({ basename: baseUrl });

// Get the application-wide store instance, prepopulating with state from the server where available.
const store = configureStore(history);

ReactDOM.render(
    <Provider store={store}>
        <ConnectedRouter history={history}>
          <ThemeProvider theme={theme}>
            <App/>
          </ThemeProvider>
        </ConnectedRouter>
    </Provider>,
    document.getElementById('root'));

registerServiceWorker();
