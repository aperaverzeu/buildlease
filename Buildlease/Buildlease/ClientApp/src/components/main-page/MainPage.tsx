import { Component } from 'react';
import { Container } from 'reactstrap';
import Globals from '../../Globals';

import BigHeader from './BigHeader';

export class MainPage extends Component {
    render() {
        return (
            <>
                <BigHeader />
                <Container>
                    <h1>Hello, world!</h1>
                    {Globals.Categories ?
                        <p>This is to be the content of the main page, i.e. "our categories", "popular", and "featured"</p>
                    :
                        <h1>YOU SHOULD NOT SEE THIS, MORTAL ONE!</h1>
                    }
                </Container>
            </>
        );
    }
}
