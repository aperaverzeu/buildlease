import { Component } from 'react';
import { Route } from 'react-router';

import { Layout } from './layout/Layout';
import { FetchData } from './FetchData';
import { Counter } from './Counter';
import AuthorizeRoute from './api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './api-authorization/ApiAuthorizationConstants';
import Test from './Test';
import Catalog from './Catalog';

import '../custom.css'

export class GenPage extends Component {
    static displayName = GenPage.name;
  
    render() {
        return(
            <Layout>
                <Route path='/catalog' component={Catalog}/>

                <Route path='/counter' component={Counter} />

                <AuthorizeRoute path='/fetch-data' component={FetchData} />
                <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />

                <Route exact path='/Test' component={Test} />
            </Layout>
        )
    }
}