import { Component } from 'react';
import { Route } from 'react-router';
import { MainPage } from './components/main-page/MainPage';
import { GenPage } from './components/GenPage';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <>
        <Route exact path='/' component={MainPage} />
        <Route path='/:smth' component={GenPage} />
      </>
    );
  }
}
