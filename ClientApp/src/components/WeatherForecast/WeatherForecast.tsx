import './WeatherForecast.scss';
import { Button, Form, FormGroup, Input, Label } from 'reactstrap';
import React, { ChangeEvent, useCallback, useEffect, useState } from 'react';
import { TitleItem } from '../../shared/interfaces/TitleItem';
import useDebounce from '../../hooks/useDebounce';
import useDocumentTitle from '../../hooks/useDocumentTitle';
import WeatherCard from './WeatherCard';

/**
 * Geocoding is the process of converting addresses (like a street address) into geographic coordinates (like latitude
 * and longitude). This function, which is called by the handleSubmit function below, uses the US Census Geocoding
 * Services API to geocode the address entered by the user into the form field.
 */
async function getGeocodingData(address: string, benchmark: string, vintage: string): Promise<any> {
  const url: string = `/api/Geocoding?address=${address}&benchmark=${benchmark}&vintage=${vintage}`;

  const response: Response = await fetch(url);
  const geocodingData: any = await response.json();

  return geocodingData;
};

async function getWeatherForecastData(latitude: number, longitude: number): Promise<any> {
  const url: string = `/api/Weather?latitude=${latitude}&longitude=${longitude}`;

  const response: Response = await fetch(url);
  const weatherForecastData: any = await response.json();

  return weatherForecastData;
};

/**
 * The WeatherForecast component, which provides the weather forecast page for the application, describing the weather
 * forecast for the current location. This is accomplished via a two-step process:
 *   1. A form field is provided to allow the user to enter an address, which is then turned into a Latitude and
 *      Longitude via the US Census Geocoding Service API.
 *   2. The Latitude and Longitude are then used to obtain the weather forecast for the location via the US National
 *      Weather Service API.
 *
 * @param props - The input properties for the component, containing in this case the title to be used for the page.
 * @returns The WeatherForecast component.
 */
const WeatherForecast = ({ title }: TitleItem): React.ReactElement => {
  useDocumentTitle(title);

  const [address, setAddress] = useState<string>('');
  const [geocodingData, setGeocodingData] = useState<any>(null);
  const [weatherForecastData, setWeatherForecastData] = useState<any>(null);

  const debouncedAddress: string = useDebounce<string>(address, 1_000);

  const decimalDigits: number = 4;
  const latitude: number | null = geocodingData?.result?.addressMatches[0]?.coordinates?.y ?? null;
  const longitude: number | null = geocodingData?.result?.addressMatches[0]?.coordinates?.x ?? null;
  const latLongPlaceholder: string = "--";

  const formatCoordinate = (coordinate: number | null, decimalDigits: number = 4, isLatitude: boolean): string => {
    if (coordinate === null) {
      return latLongPlaceholder;
    }

    const direction: string = isLatitude ? (coordinate >= 0 ? 'N' : 'S') : (coordinate >= 0 ? 'E' : 'W');
    const formattedCoordinate: string = Math.abs(coordinate).toFixed(decimalDigits);

    return `${formattedCoordinate}° ${direction}`
  };

  /**
   * Handles the submission of an address into the form field. This sets off the process described in the component
   * documentation above.
   *
   * @param event - The form event that triggered the submission.
   */
  const handleSubmit = useCallback(async (): Promise<void> => {
    try {
      if (!debouncedAddress) {
        return;
      }

      const geocodingData: any = await getGeocodingData(
        encodeURIComponent(debouncedAddress),
        'Public_AR_Current',
        'Current'
      );

      const weatherForecastData: any = await getWeatherForecastData(
        geocodingData?.result?.addressMatches[0]?.coordinates?.y,
        geocodingData?.result?.addressMatches[0]?.coordinates?.x
      );

      setGeocodingData(geocodingData);
      setWeatherForecastData(weatherForecastData);
    } catch (error) {
      console.error('Error getting weather forecast data: ', error);
    }
  }, [debouncedAddress]);

  useEffect(() => {
    if (debouncedAddress) {
      handleSubmit();
    }
  }, [debouncedAddress, handleSubmit]);

  return (
    <>
      <section>
        <h1>
          Insightful Forecast
        </h1>
      </section>

      <section>
        <FormGroup>
          <Form onSubmit={handleSubmit}>
            <Label for="address">
              Address
            </Label>
            <Input
              className="mb-3"
              id="address"
              name="address"
              placeholder="Enter an address..."
              type="text"
              value={address}
              onChange={(event: ChangeEvent<HTMLInputElement>): void => setAddress(event.target.value)}
            />
            <Button color="primary" onClick={handleSubmit}>
              Get Forecast
            </Button>
          </Form>
        </FormGroup>
      </section>

      <section>
        <div className="row row-cols-1 row-cols-md-2 row-cols-lg-3">
          {weatherForecastData?.properties?.periods?.map((period: any): React.ReactElement => (
            <div className="col mb-4" key={period.name}>
              <WeatherCard
                icon={period.icon}
                name={period.name}
                temperature={period.temperature}
                temperatureUnit={period.temperatureUnit}
                shortForecast={period.shortForecast}
                detailedForecast={period.detailedForecast}
              />
            </div>
          ))}
        </div>
      </section>

      <section>
        <h3>
          Additional Address Information
        </h3>

        <div className="d-flex lead">
          <p className="me-2">
            <strong>Latitude:</strong> {formatCoordinate(latitude, decimalDigits, true)}
          </p>
          <p>
            <strong>Longitude:</strong> {formatCoordinate(longitude, decimalDigits, false)}
          </p>
        </div>
      </section>
    </>
  );
};

export default WeatherForecast;
