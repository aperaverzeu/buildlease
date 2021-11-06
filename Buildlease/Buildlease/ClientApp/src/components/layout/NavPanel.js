import { Component } from 'react';
import { Collapse, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { StarBorderOutlined as Favorites, NotificationsOutlined as Notifications, ShoppingCartOutlined as Cart, AccountCircleOutlined as Profile } from "@material-ui/icons"
import { Link } from 'react-router-dom';
import { LoginMenu } from '../api-authorization/LoginMenu';

export class NavPanel extends Component {
    static displayName = NavPanel.name;

    constructor(props) {
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
                            <NavLink tag={Link} className='text-light' to='/favorites'>
                                <Favorites/>
                            </NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink tag={Link} className='text-light' to='/notifications'>
                                <Notifications/>
                            </NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink tag={Link} className='text-light' to='/cart'>
                                <Cart/>
                            </NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink tag={Link} className='text-light' to='/profile'>
                                <Profile/>
                            </NavLink>
                        </NavItem>
                        <LoginMenu />
                    </ul>
                </Collapse>
            </>
        )
    }
}

export default NavPanel
