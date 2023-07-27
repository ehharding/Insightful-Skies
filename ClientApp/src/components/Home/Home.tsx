import { Button, Col, Container, Row } from 'reactstrap';
import { Link } from 'react-router-dom';
import React from 'react';
import { Technology, technologies } from './Technologies';
import { TitleItem } from '../../shared/interfaces/TitleItem';
import useDocumentTitle from '../../hooks/useDocumentTitle';

/**
 * The Home component, which provides the home page for the application, describing the application and providing some
 * basic information about it.
 *
 * @param props - The input properties for the component, containing in this case the title to be used for the page.
 * @returns The Home component.
 */
const Home = ({ title }: TitleItem): React.ReactElement => {
  useDocumentTitle(title);

  return (
    <>
      <section>
        <h1>
          Welcome to Insightful Skies!
        </h1>

        <p className="lead">
          This is a simple but full-stack web application that allows you to view the weather forecast for a given
          address. It also sets the foundation for a more complex and scalable application, with a number of additional
          features.
        </p>

        <Container className="text-center">
          <Button color="primary" tag={Link} to="/weather-forecast">
            Find a Weather Forecast!
          </Button>
        </Container>
      </section>

      <section>
        <h3>
          Technologies Used (Non-Exhaustive)
        </h3>
        {technologies.map(({ name, description, link }: Technology): React.ReactElement => (
          <Row key={name}>
            <Col xs={3} style={{ whiteSpace: 'nowrap' }}>
              <a href={link} rel="noopener noreferrer" target="_blank">
                {name}
              </a>
            </Col>
            <Col xs={8}>
              {description}
            </Col>
          </Row>
        ))}
      </section>
    </>
  );
};

export default Home;
