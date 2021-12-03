import {Switch} from 'react-router-dom';
import AuthorizeRoute from '.././api-authorization/AuthorizeRoute';

import AdminCategory from "./category-panel/AdminCategory";
import AdminProduct from "./product-panel/AdminProduct";
import AdminMain from "./AdminMain";

export default function Admin() {
    return (
        <>
            <Switch>
                <AuthorizeRoute path='/admin/main' component={AdminMain}/>
                <AuthorizeRoute path='/admin/product' component={AdminProduct}/>
                <AuthorizeRoute path='/admin/categories' component={AdminCategory}/>
            </Switch>
        </>
    );
}