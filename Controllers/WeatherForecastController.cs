/*
 * Copyright 2023 Evan H. Harding
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with
 * the License. You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on
 * an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the
 * specific language governing permissions and limitations under the License.
 */

using InsightfulSkies.WeatherForecast;
using InsightfulSkies.WeatherGrid;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace InsightfulSkies.Controllers
{
    /*
     * The WeatherForecastController class is a .NET Core Web API controller that handles requests to and responses from
     * the US National Weather Service API.
     */

    /// <summary>
    ///     The <see cref="WeatherForecastController" /> class is a .NET Core Web API controller that handles requests
    ///     to and responses from the US National Weather Service API.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The controller is of type <see cref="ControllerBase" /> and is decorated with the
    ///         <see cref="ApiControllerAttribute" /> and <see cref="RouteAttribute" /> attributes. This indicates to
    ///         .NET that this class is a web API controller and defines the route that the controller (and its methods)
    ///         will respond to.
    ///     </para>
    ///     <para>
    ///         The class class contains the following methods:
    ///         <list type="bullet">
    ///             <item>
    ///                 <term>Get</term>
    ///                 <description>
    ///                     A GET method that retrieves weather forecast information based on a provided latitude and
    ///                     longitude.
    ///                 </description>
    ///             </item>
    ///         </list>
    ///     </para>
    /// </remarks>
    [ApiController]
    [Route("/api/Weather")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        // Constructs an instance of the WeatherForecastController class with an injected IHttpClientFactory.
        /// <summary>
        ///     Constructs an instance of the <see cref="WeatherForecastController" /> class with an injected
        ///     <see cref="IHttpClientFactory" />.
        /// </summary>
        /// <param name="clientFactory">An <see cref="IHttpClientFactory" /> instance.</param>
        public WeatherForecastController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        // A GET method that retrieves weather forecast information based on a provided latitude and longitude.
        /// <summary>
        ///     A GET method that retrieves weather forecast information based on a provided latitude and longitude.
        /// </summary>
        /// <seealso href="https://www.weather.gov/documentation/services-web-api">
        ///     US National Weather Service Web API
        /// </seealso>
        /// <param name="latitude">The latitude of the location to retrieve weather forecast information for.</param>
        /// <param name="longitude">The longitude of the location to retrieve weather forecast information for.</param>
        /// <returns>
        ///     A <see cref="Task" /> of type <see cref="IActionResult" /> that contains, if successful, an
        ///     <see cref="OkObjectResult" /> containing the <see cref="WeatherForecastResponse" /> object that was
        ///     returned from the National Weather Service API. If unsuccessful, an <see cref="ObjectResult" />
        ///     containing the status code and reason for the unsuccessful HTTP request is returned.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> Get(string latitude, string longitude)
        {
            var httpClient = _clientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("(InsightfulSkies/0.1.0, ehharding@insightfulskies.com)");
            var gridUri = $"https://api.weather.gov/points/{latitude},{longitude}";

            var gridHttpResponseMessage = await httpClient.GetAsync(gridUri);
            if (gridHttpResponseMessage.IsSuccessStatusCode)
            {
                var gridJsonString = await gridHttpResponseMessage.Content.ReadAsStringAsync();
                var gridResult = JsonSerializer.Deserialize<WeatherGridResponse>(gridJsonString);

                if (gridResult != null)
                {
                  // Get the forecast data from the forecast URI.
                  var forecastUri = gridResult.Properties?.Forecast;

                  var forecastHttpResponseMessage = await httpClient.GetAsync(forecastUri);
                  if (forecastHttpResponseMessage.IsSuccessStatusCode)
                  {
                      var forecastJsonString = await forecastHttpResponseMessage.Content.ReadAsStringAsync();
                      var forecastResult = JsonSerializer.Deserialize<WeatherForecastResponse>(forecastJsonString);

                      return Ok(forecastResult);
                  }
                  else
                  {
                      return StatusCode((int)forecastHttpResponseMessage.StatusCode, forecastHttpResponseMessage.ReasonPhrase);
                  }
                }
                else
                {
                    return StatusCode((int)gridHttpResponseMessage.StatusCode, "Unable to deserialize weather grid response.");
                }
            }
            else
            {
                return StatusCode((int)gridHttpResponseMessage.StatusCode, gridHttpResponseMessage.ReasonPhrase);
            }
        }
    }
}
