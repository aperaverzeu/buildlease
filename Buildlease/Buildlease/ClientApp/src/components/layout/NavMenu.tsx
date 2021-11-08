import { Component } from 'react';
import { Container, Navbar, NavbarBrand } from 'reactstrap';
import { Link } from 'react-router-dom';
import NavPanel from './NavPanel';
import logoIcon from '../../assets/tmp-logo.png'

import styles from './layout.module.css';

type NavBarState = { collapsed?: boolean };

type NavMenuProps = { state?: NavBarState };

export class NavMenu extends Component<NavMenuProps, NavBarState> {
    constructor(props: NavMenuProps) {
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
            <Navbar className={`navbar-expand-sm navbar-toggleable-sm ${styles.wideBar}`} light>
                <Container className='d-flex'>
                    <NavbarBrand tag={Link} to="/">
                        <img src={logoIcon} className={styles.logo} alt='' />
                    </NavbarBrand>
                    <NavPanel/>
                </Container>
            </Navbar>
        );
    }
}
