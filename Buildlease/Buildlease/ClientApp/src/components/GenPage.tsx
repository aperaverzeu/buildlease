import { Component, useState } from 'react';
import { Route, Switch } from 'react-router-dom';

import AuthorizeRoute from './api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './api-authorization/ApiAuthorizationConstants';

import Layout from './layout/Layout';

import NotFound from './NotFound';
import Cart from './cart/Cart';
import Profile from './profile/Profile';
import Catalog from './catalog/Catalog';
import Globals from '../Globals';

import styles from './gen_page.module.css';

export default function GenPage() {
    
    const [OK, setOK] = useState<boolean>(Globals.Categories !== undefined);
    if (!OK) Globals.OnCategoriesLoadedListeners!.push(() => setOK(true));
    
    return (
        <Layout>
        {OK ?
            <Switch>
                <Route path='/catalog/:stringCategoryId?' component={Catalog}/>

                    <AuthorizeRoute path='/cart' component={Cart}/>
                    <AuthorizeRoute path='/profile' component={Profile}/>

                    <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />

                    <Route component={NotFound} />
                </Switch>
            :
                <h1>YOU SHOULD NOT SEE THIS, MORTAL ONE!</h1>
            }
        </Layout>
    )
}
