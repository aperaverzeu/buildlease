import { Component } from 'react';
import { Route, Switch } from 'react-router';

import AuthorizeRoute from './api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './api-authorization/ApiAuthorizationConstants';

import Layout from './layout/Layout';

import Catalog from './Catalog';
import NotFound from './NotFound';
import Cart from './cart/Cart';
import Profile from './profile/Profile';

import Test from './Test';
import FetchData from './FetchData';
import Counter from './Counter';

export class GenPage extends Component {
    // static displayName = GenPage.name;
  
    render() {
        return(
            <Layout>
                <Switch>
                    <Route path='/catalog' component={Catalog}/>

                    <Route path='/cart' component={Cart}/> {/* for authenticated users */}
                    <Route path='/profile' component={Profile}/> {/* for authenticated users */}

                    <AuthorizeRoute path='/fetch-data' component={FetchData} />
                    <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />

                    <Route exact path='/test' component={Test} />
                    <Route path='/counter' component={Counter} />

                    <Route component={NotFound} />
                </Switch>
            </Layout>
        )
    }
}