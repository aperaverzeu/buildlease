import { Component } from 'react';
import { Route, Switch } from 'react-router-dom';

import AuthorizeRoute from './api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './api-authorization/ApiAuthorizationConstants';

import Layout from './layout/Layout';

import Catalog from './Catalog';
import NotFound from './NotFound';
import Cart from './cart/Cart';
import Profile from './profile/Profile';

export class GenPage extends Component {
    render() {
        return(
            <Layout>
                <Switch>
                    <Route path='/catalog' component={Catalog}/>

                    <Route path='/cart' component={Cart}/> {/* should be for authenticated users */}
                    <Route path='/profile' component={Profile}/> {/* should be for authenticated users */}

                    <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />

                    <Route component={NotFound} />
                </Switch>
            </Layout>
        )
    }
}
