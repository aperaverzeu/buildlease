import { Route } from 'react-router-dom';
import MainPage from './components/main-page/MainPage';
import GenPage from './components/GenPage';

import Globals from './Globals';

import 'antd/dist/antd.css';
import API from './API';

export default function App() {

  if (!Globals.Categories)
    API.GetAllCategories()
      .then(res => Globals.Categories = res)
      .then(() => Globals.OnCategoriesLoadedListeners!.forEach(f => f()))
      .then(() => Globals.OnCategoriesLoadedListeners = null);

  return (
    <>
      <Route exact path='/' component={MainPage} />
      <Route path='/:smth' component={GenPage} />
    </>
  );
}
