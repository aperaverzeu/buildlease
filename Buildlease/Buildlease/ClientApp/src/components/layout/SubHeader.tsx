import { Route, Switch } from 'react-router-dom';

import CatalogState from '../catalog/CatalogState';
import CartState from '../cart/CartState';
import ProfileState from '../profile/ProfileState';

import styles from './layout.module.css';

export default function SubHeader() {
    return (
        <div className={`d-flex justify-content-between align-items-center ${styles.wideBar}`}>
            <Switch>
                <Route path='/catalog' component={CatalogState}/>
                <Route path='/cart' component={CartState}/>
                <Route path='/profile' component={ProfileState}/>
            </Switch>
        </div>
    );
}
