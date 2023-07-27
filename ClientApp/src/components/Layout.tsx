import { Container } from 'reactstrap';
import NavMenu from './NavMenu';
import React from 'react';

interface LayoutProps {
  /** The child elements to be rendered within the layout. */
  children: React.ReactNode;
}

/**
 * The Layout component, which provides for basic top-level layout of the application, wrapping the navigation menu and
 * the main content area in a
 *
 * @param props - The input properties for the component, used here to provide the child elements to be rendered within.
 * @returns The Layout component.
 */
const Layout = (props: LayoutProps): React.ReactElement => {
  return (
    <div>
      <NavMenu />
      <Container tag="main">
        {props.children}
      </Container>
    </div>
  );
};

export default Layout;
