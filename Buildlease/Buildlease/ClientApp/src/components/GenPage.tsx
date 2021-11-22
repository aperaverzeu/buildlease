// routing
import { Route, Switch } from 'react-router-dom';

// auth
import ApiAuthorizationRoutes from './api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './api-authorization/ApiAuthorizationConstants';
import AuthorizeRoute from './api-authorization/AuthorizeRoute';

// pages components
import Catalog from './catalog/Catalog';
import Cart from './cart/Cart';
import Profile from './profile/Profile';

// styles (do we need em here tho?)
import styles from './gen_page.module.css';

export default function GenPage() {
    return (
        <>
            <Switch>
                <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
                <AuthorizeRoute path='/cart' component={Cart}/>
                <AuthorizeRoute path='/profile'  component={Profile}/>
                <Route path='/catalog' component={Catalog}/>
            </Switch>
        </>
    )
}
