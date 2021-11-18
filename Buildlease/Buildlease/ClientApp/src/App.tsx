import { Route } from 'react-router-dom';
import { MainPage } from './components/main-page/MainPage';
import { GenPage } from './components/GenPage';

import Globals from './Globals';

import './base.module.css';
import 'antd/dist/antd.css';
import API from './API';


export default function App() {

  API.GetAllCategories()
    .then(res => Globals.Categories = res);

  return (
    <>
      <Route exact path='/' component={MainPage} />
      <Route path='/:smth' component={GenPage} />
    </>
  );
}
