import { Route } from 'react-router-dom';
import AuthorizeRoute from '../api-authorization/AuthorizeRoute';

function PageState() {
    return (
        <>
            <AuthorizeRoute path='/cart'>
                <h1>Your Cart:</h1>
            </AuthorizeRoute>
            <AuthorizeRoute path='/profile'>
                <h1>Your Profile:</h1>
            </AuthorizeRoute>
            <Route path='/catalog'>
                <p>*Breadcrumb to be here*</p>
            </Route>
        </>
    )
}

export default PageState
