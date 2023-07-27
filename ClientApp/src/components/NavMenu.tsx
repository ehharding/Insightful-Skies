import './NavMenu.scss';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import React, { useState } from 'react';

/**
 * The navigation menu component, which provides navigation links to other pages in the application.
 *
 * @returns The navigation menu component.
 */
const NavMenu = (): React.ReactElement => {
  /** The state variable that determines whether or not the navigation menu is collapsed. */
  const [collapsed, setCollapsed] = useState<boolean>(true);

  /**
   * Toggles the navigation menu between collapsed and expanded.
   */
  const toggleNavbar = (): void => {
    setCollapsed(!collapsed);
  };

  return (
    <header>
      <Navbar className="border-bottom box-shadow mb-3 navbar-expand-sm navbar-toggleable-sm ng-white" container light>
        <NavbarBrand tag={Link} to="/">Insightful Skies</NavbarBrand>
        <NavbarToggler className="me-2" onClick={toggleNavbar} />
        <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!collapsed} navbar>
          <ul className="flex-grow navbar-nav">
            <NavItem>
              <NavLink className="text-dark" tag={Link} to="/">Home</NavLink>
            </NavItem>
            <NavItem>
              <NavLink className="text-dark" tag={Link} to="/weather-forecast">Insightful Forecast</NavLink>
            </NavItem>
          </ul>
        </Collapse>
      </Navbar>
    </header>
  );
};

export default NavMenu;
