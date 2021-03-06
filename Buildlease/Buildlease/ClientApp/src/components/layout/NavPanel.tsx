import { Component } from 'react';
import { Collapse, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import {
    ShoppingCartOutlined as Cart, AccountCircleOutlined as Profile, FormatListBulleted as Catalog, History
} from "@material-ui/icons"
import { Link } from 'react-router-dom';

import styles from './layout.module.css';

type NavBarState = { collapsed?: boolean };

type NavPanelProps = { state?: NavBarState };

export class NavPanel extends Component<NavPanelProps, NavBarState> {
    constructor(props: NavPanelProps) {
        super(props);

        this.toggleNavbar = this.toggleNavbar.bind(this);
        this.state = {
            collapsed: true
        };
    }

    toggleNavbar() {
        this.setState({
            collapsed: !this.state.collapsed
        });
    }

    render() {
        return (
            <>
                <NavbarToggler onClick={this.toggleNavbar} className='mr-2' />
                <Collapse className='d-sm-inline-flex flex-sm-row-reverse' isOpen={!this.state.collapsed} navbar>
                    <ul className='navbar-nav flex-grow d-flex align-items-center'>
                        <NavItem>
                            <NavLink tag={Link} className='text-light' to='/catalog'>
                                <Catalog className={styles.navPanelIcon}/>
                            </NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink tag={Link} className='text-light' to='/cart'>
                                <Cart className={styles.navPanelIcon}/>
                            </NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink tag={Link} className='text-light' to='/profile'>
                                <Profile className={styles.navPanelIcon}/>
                            </NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink tag={Link} className='text-light' to='/order-history'>
                                <History className={styles.navPanelIcon}/>
                            </NavLink>
                        </NavItem>
                        {
                        // <LoginMenu />
                        }
                    </ul>
                </Collapse>
            </>
        )
    }
}

export default NavPanel
