import { Component } from 'react';
import { Container } from 'reactstrap';
import { Header } from './Header';

export class Layout extends Component {
    render() {
        return (
            <>
                <Header />
                <Container>
                    {this.props.children}
                </Container>
            </>
        );
    }
}

export default Layout
