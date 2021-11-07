import { Component } from 'react';
import { Route } from 'react-router';
import { Container } from 'reactstrap';

import PageState from './PageState';
import SortRule from './SortRule';

import styles from './layout.module.css';

export class SubHeader extends Component {
    static displayName = SubHeader.name;

    render() {
        return (
            <Container className={`d-flex ${styles.wideBar}`}>
                <PageState/>
                <Route path='/catalog'>
                    <SortRule/>
                </Route>
            </Container>
        );
    }
}
