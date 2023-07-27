import { Card, CardBody, CardImg, CardText, CardTitle } from 'reactstrap';
import React from 'react';

interface WeatherCardProps {
  icon: string;
  name: string;
  temperature: number;
  temperatureUnit: string;
  shortForecast: string;
  detailedForecast: string;
}

const WeatherCard: React.FC<WeatherCardProps> = ({
  icon,
  name,
  temperature,
  temperatureUnit,
  shortForecast,
  detailedForecast
}) => {
  return (
    <Card>
      <CardBody>
        <CardTitle tag="h5">{name}</CardTitle>
        <CardImg alt={shortForecast} src={icon} style={{ width: '75px' }} />
        <CardText>
          {temperature} {temperatureUnit}
        </CardText>
        <CardText>{detailedForecast}</CardText>
      </CardBody>
    </Card>
  );
}

export default WeatherCard;
