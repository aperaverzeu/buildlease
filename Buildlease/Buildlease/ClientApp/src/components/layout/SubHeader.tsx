import { Component } from 'react';
import { Route } from 'react-router-dom';

import PageState from './PageState';
import SortRule from './SortRule';

import styles from './layout.module.css';

export class SubHeader extends Component {
    render() {
        return (
            <div className={`d-flex justify-content-between align-items-center ${styles.wideBar}`}>
                <PageState/>
                <Route path='/catalog'>
                    <SortRule/>
                </Route>
            </div>
        );
    }
}
