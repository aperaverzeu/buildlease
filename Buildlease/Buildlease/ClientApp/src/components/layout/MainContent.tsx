// routing
import { Route, Switch } from 'react-router-dom';

import Catalog from '../catalog/Catalog';

export default function MainContent() {
    return(
        <div className='h-100 d-flex flex-grow-1'>
            <Switch>
                <Route path='/catalog' component={Catalog}/>
                <Route>
                    <div className='d-flex flex-grow-1 justify-content-center align-items-center'>
                        <p>Main Content</p>
                    </div>
                </Route>
            </Switch>
        </div>
    );
}
