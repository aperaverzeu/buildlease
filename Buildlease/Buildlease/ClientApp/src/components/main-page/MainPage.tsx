import { Component } from 'react';
import { Container } from 'reactstrap';

import BigHeader from './BigHeader';

export class MainPage extends Component {
    render() {
        return (
            <>
                <BigHeader />
                <Container>
                    <h1>Hello, world!</h1>
                    <p>This is to be the content of the main page, i.e. "our categories", "popular", and "featured"</p>
                </Container>
            </>
        );
    }
}
