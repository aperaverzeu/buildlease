// routing
import { Route, Switch } from 'react-router-dom';

// auth
import ApiAuthorizationRoutes from './api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './api-authorization/ApiAuthorizationConstants';
import AuthorizeRoute from './api-authorization/AuthorizeRoute';

import { useState } from 'react';
import Globals from '../Globals';

// pages components
import Catalog from './catalog/Catalog';
import Cart from './cart/Cart';
import Profile from './profile/Profile';
import Product from "./product/Product";
import Order from "./order/Order";

// styles (do we need em here tho?)
import './gen_page.module.css';

export default function GenPage() {

    const [OK, setOK] = useState<boolean>(Globals.Categories !== undefined);
    if (!OK) Globals.OnCategoriesLoadedListeners!.push(() => setOK(true));

    return (
        <>
            {OK ?
                <Switch>
                    <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
                    <AuthorizeRoute path='/cart' component={Cart}/>
                    <AuthorizeRoute path='/profile'  component={Profile}/>
                    <AuthorizeRoute path='/orders/:stringOrderId' component={Order}/>
                    <Route path='/catalog/:stringCategoryId?' component={Catalog}/>
                    <Route path='/products/:stringProductId' component={Product}/>
                </Switch>
            :
                <h1>YOU SHOULD NOT SEE THIS, MORTAL ONE!</h1>
            }
            
        </>
    )
}
