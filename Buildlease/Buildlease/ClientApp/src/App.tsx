import { Route } from 'react-router-dom';
import { MainPage } from './components/main-page/MainPage';
import { GenPage } from './components/GenPage';

import Globals from './Globals';

import './base.module.css';
import 'antd/dist/antd.css';
import API from './API';
import { useState } from 'react';


export default function App() {

  const [OK, setOK] = useState<boolean>(false);
  
  API.GetAllCategories()
    .then(res => Globals.Categories = res)
    .then(() => setOK(true));

  return (
    <>
      {OK &&
      <>
        <Route exact path='/' component={MainPage} />
        <Route path='/:smth' component={GenPage} />
      </>
      }
    </>
  );
}
