import { Component } from 'react';
import { Route } from 'react-router-dom';
import { MainPage } from './components/main-page/MainPage';
import { GenPage } from './components/GenPage';

import './base.module.css';
import 'antd/dist/antd.css';

export default class App extends Component {
  render () {
    return (
      <>
        <Route exact path='/' component={MainPage} />
        <Route path='/:smth' component={GenPage} />
      </>
    );
  }
}
