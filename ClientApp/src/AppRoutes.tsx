import Forecast from "./components/WeatherForecast/WeatherForecast";
import Home from "./components/Home/Home";
import React from "react";

const AppRoutes = [
  {
    index: true,
    element: <Home title="Insightful Skies" />
  },
  {
    path: '/weather-forecast',
    element: <Forecast title="Weather Forecast" />
  }
];

export default AppRoutes;
