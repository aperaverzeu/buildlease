import { Component } from 'react';
import { Container } from 'reactstrap';
import { Header } from './Header';
import { SubHeader } from './SubHeader';

export class Layout extends Component {
    static displayName = Layout.name;

    render() {
        return (
            <div>
                <Header />
                <SubHeader/>
                <Container>
                    {this.props.children}
                </Container>
            </div>
        );
    }
}

export default Layout
