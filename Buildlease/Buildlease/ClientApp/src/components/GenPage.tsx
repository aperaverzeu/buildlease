// routing
import {Route, Switch} from 'react-router-dom';

import {useState} from 'react';
import Globals from '../Globals';

// pages components
import Catalog from './catalog/Catalog';
import Cart from './cart/Cart';
import Profile from './profile/Profile';
import Product from "./product/Product";
import Order from "./order/Order";
import Admin from "./admin/Admin";
import OrderHistory from "./order-history/OrderHistory";
import AdminProduct from "./admin/product-panel/AdminProduct";
import AdminCategory from "./admin/category-panel/AdminCategory";

// styles (do we need em here tho?)
import './gen_page.module.css';
import API from '../API';

export default function GenPage() {

    const [OK, setOK] = useState<boolean>(Globals.Categories !== undefined);
    if (!OK) Globals.OnCategoriesLoadedListeners!.push(() => setOK(true));

    return (
        <>
            {OK ?
                <Switch>
                    { API.IsAuthorized() &&
                    <>
                        <Route path='/cart' component={Cart}/>
                        <Route path='/profile' component={Profile}/>
                        <Route path='/orders/:stringOrderId' component={Order}/>
                        <Route path='/order-history' component={OrderHistory}/>
                        <Route path='/admin/products/:stringProductId?' component={AdminProduct}/>
                        <Route path='/admin/categories' component={AdminCategory}/>
                        <Route path='/admin' component={Admin}/>
                    </>}
                    {
                    // <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes}/>
                    }
                    <Route path='/catalog/:stringCategoryId?' component={Catalog}/>
                    <Route path='/products/:stringProductId' component={() => <Product isHistoric={false}/>}/>
                    <Route path='/archived-products/:stringProductOrderId' component={() => <Product isHistoric={true}/>}/>
                </Switch>
                :
                <h1>YOU SHOULD NOT SEE THIS, MORTAL ONE!</h1>
            }

        </>
    )
}
