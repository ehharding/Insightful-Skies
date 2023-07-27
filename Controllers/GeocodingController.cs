using InsightfulSkies.Geocoding;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace InsightfulSkies.Controllers
{
    [Route("/api/Geocoding")]
    [ApiController]
    public class GeocodingController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public GeocodingController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string address, string benchmark, string vintage)
        {
            var client = _clientFactory.CreateClient();
            var encodedAddress = WebUtility.UrlEncode(address);
            var url = $"https://geocoding.geo.census.gov/geocoder/locations/onelineaddress" +
                      $"?address={encodedAddress}&benchmark={benchmark}&vintage={vintage}&format=json";

            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<GeocodingResponse>(jsonString);

                return Ok(result);
            }
            else
            {
                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
