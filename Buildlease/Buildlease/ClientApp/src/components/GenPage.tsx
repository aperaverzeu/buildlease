// routing
import { Route, Switch } from 'react-router-dom';

// auth
import ApiAuthorizationRoutes from './api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './api-authorization/ApiAuthorizationConstants';
import AuthorizeRoute from './api-authorization/AuthorizeRoute';

// gen layout
import SubHeader from './layout/SubHeader';
import SideMenu from './layout/SideMenu';
import MainContent from './layout/MainContent';

// styles (do we need em here tho?)
import styles from './gen_page.module.css';

export default function GenPage() {
    return (
        <>
            <Switch>
                <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
                <Route>
                    { /* I kmow it looks like shit but I can explain */ }
                    <AuthorizeRoute path='/cart' component={ () => { return(<></>) } }/>
                    <AuthorizeRoute path='/profile'  component={ () => { return(<></>) } }/>

                    <SubHeader/>
                    <div>
                        <SideMenu/>
                        <MainContent/>
                    </div>
                </Route>
            </Switch>
        </>
    )
}
