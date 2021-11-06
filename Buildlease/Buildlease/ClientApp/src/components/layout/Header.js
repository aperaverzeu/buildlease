import { Component } from 'react';
import { NavMenu } from './NavMenu';

import styles from './layout.module.css';

export class Header extends Component {
    static displayName = Header.name;

    render() {
        return (
            <div className={styles.header}>
                <NavMenu/>
            </div>
        );
    }
}