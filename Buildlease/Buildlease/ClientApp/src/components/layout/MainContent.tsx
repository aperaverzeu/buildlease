// routing
import { Route, Switch } from 'react-router-dom';

import Catalog from '../catalog/Catalog';

export default function MainContent() {
    return(
        <>
            Main Content
            
            <Route path='/catalog' component={Catalog}/>
        </>
    );
}
