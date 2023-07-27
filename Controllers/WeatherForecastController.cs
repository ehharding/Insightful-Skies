using InsightfulSkies.WeatherForecast;
using InsightfulSkies.WeatherGrid;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace InsightfulSkies.Controllers
{
    [Route("/api/Weather")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public WeatherForecastController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string latitude, string longitude)
        {
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.UserAgent.ParseAdd("(InsightfulSkies/0.1.0, ehharding@insightfulskies.com)");

            var url = $"https://api.weather.gov/points/{latitude},{longitude}";

            var gridResponse = await client.GetAsync(url);
            if (gridResponse.IsSuccessStatusCode)
            {
                var gridJsonString = await gridResponse.Content.ReadAsStringAsync();
                var gridResult = JsonSerializer.Deserialize<WeatherGridResponse>(gridJsonString);

                if (gridResult != null)
                {
                  // Get the forecast URL from the properties.
                  var forecastUrl = gridResult.Properties?.Forecast;

                  // Get the forecast data from the forecast URL.
                  var forecastResponse = await client.GetAsync(forecastUrl);
                  if (forecastResponse.IsSuccessStatusCode)
                  {
                      var forecastJsonString = await forecastResponse.Content.ReadAsStringAsync();
                      var forecastResult = JsonSerializer.Deserialize<WeatherForecastResponse>(forecastJsonString);

                      return Ok(forecastResult);
                  }
                  else
                  {
                      return StatusCode((int)forecastResponse.StatusCode, forecastResponse.ReasonPhrase);
                  }
                }
                else
                {
                    return StatusCode((int)gridResponse.StatusCode, "Unable to deserialize weather grid response.");
                }
            }
            else
            {
                return StatusCode((int)gridResponse.StatusCode, gridResponse.ReasonPhrase);
            }
        }
    }
}
