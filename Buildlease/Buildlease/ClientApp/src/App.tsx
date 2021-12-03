// routing
import { Route, Switch } from 'react-router-dom';

// the root stuff to be routed
import Layout from './components/layout/Layout';
import MainPage from './components/main-page/MainPage';
import GenPage from './components/GenPage';
import NotFound from './components/NotFound';

// auth
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';

// Rigorich
import Globals from './Globals';
import API from './API';

// antd
import 'antd/dist/antd.css';

export default function App() {

    if (!Globals.Categories)
        API.GetAllCategories()
            .then(res => Globals.Categories = res)
            .then(() => Globals.OnCategoriesLoadedListeners!.forEach(f => f()))
            .then(() => Globals.OnCategoriesLoadedListeners = null);

    return (
        <Switch>
            <Route exact path='/' component={MainPage} />
            <Route>
                <Layout>
                    <Switch>
                        <Route path={
                            [
                                '/catalog/:stringCategoryId?',
                                '/products/:stringProductId',
                                '/archived-products/:stringProductOrderId',
                                '/orders/:stringOrderId',
                                '/cart',
                                '/profile',
                                '/order-history',
                                '/admin',
                                // to be continued...
                                `${ApplicationPaths.ApiAuthorizationPrefix}`
                            ]
                        } component={GenPage} />

                        <Route component={NotFound} />
                    </Switch>
                </Layout>
            </Route>
        </Switch>
    );
}
