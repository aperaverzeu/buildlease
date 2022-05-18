import {Route, Switch} from 'react-router-dom';

import AdminCategory from "./category-panel/AdminCategory";
import AdminProduct from "./product-panel/AdminProduct";
import AdminMain from "./AdminMain";
import API from '../../API';

export default function Admin() {
    return (
        <>
        { API.IsAuthorized()
        ?
            <Switch>
                <Route path='/admin/main' component={AdminMain}/>
                <Route path='/admin/products/:productStringId?' component={AdminProduct}/>
                <Route path='/admin/categories' component={AdminCategory}/>
            </Switch>
        :
            <p>Nope</p>
        }
        </>
    );
}