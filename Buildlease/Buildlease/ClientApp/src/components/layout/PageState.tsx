import { Route } from 'react-router-dom';

function PageState() {
    return (
        <>
            <Route path='/cart'>
                <h1>Your Cart:</h1>
            </Route>
            <Route path='/profile'>
                <h1>Your Profile:</h1>
            </Route>
            <Route path='/catalog'>
                <p>*Breadcrumb to be here*</p>
            </Route>
        </>
    )
}

export default PageState
