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

using InsightfulSkies.Geocoding;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace InsightfulSkies.Controllers
{
    /*
     * The GeocodingController class is a .NET Core Web API controller that handles requests to and responses from the
     * US Census Geocoding API.
     */
    /// <summary>
    ///     The <see cref="GeocodingController" /> class is a .NET Core Web API controller that handles requests to and
    ///     responses from the US Census Geocoding API.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The controller is of type <see cref="ControllerBase" /> and is decorated with the
    ///         <see cref="ApiControllerAttribute" /> and <see cref="RouteAttribute" /> attributes. This indicates to
    ///         .NET
    ///     </para>
    ///     <para>
    ///         that this class is a web API controller and defines the route that the controller (and its methods) will
    ///         respond to. The class class contains the
    ///     </para>
    ///     <para>
    ///         following methods:
    ///         <list type="bullet">
    ///             <item>
    ///                 <term>Get</term>
    ///                 <description>
    ///                     A GET method that retrieves geocoding information based on a provided address.
    ///                 </description>
    ///             </item>
    ///         </list>
    ///     </para>
    /// </remarks>
    [ApiController]
    [Route("/api/Geocoding")]
    public class GeocodingController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        // Constructs an instance of the GeocodingController class with an injected IHttpClientFactory.
        /// <summary>
        ///     Constructs an instance of the <see cref="GeocodingController" /> class with an injected
        ///     <see cref="IHttpClientFactory" />.
        /// </summary>
        /// <param name="clientFactory">An <see cref="IHttpClientFactory" /> instance.</param>
        public GeocodingController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        // A GET method that retrieves geocoding information based on a provided address, benchmark, and vintage.
        /// <summary>
        ///     A GET method that retrieves geocoding information based on a provided address, benchmark, and vintage.
        /// </summary>
        /// <seealso href="https://geocoding.geo.census.gov/geocoder/Geocoding_Services_API.pdf">
        ///     Geocoding Services Web API
        /// </seealso>
        /// <param name="address">A single line containing the full address to be geocoded.</param>
        /// <param name="benchmark">An ID or name of the locator version that should be searched.</param>
        /// <param name="vintage">An ID or name of the vintage of geography that is desired for the lookup.</param>
        /// <returns>
        ///     A <see cref="Task" /> of type <see cref="IActionResult" /> that contains, if successful, an
        ///     <see cref="OkObjectResult" /> containing the <see cref="GeocodingResponse" /> object that was returned
        ///     from the US Census Geocoding API. If unsuccessful, an <see cref="ObjectResult" /> containing the status
        ///     code and reason for the unsuccessful HTTP request is returned.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> Get(string address, string benchmark, string vintage)
        {
            var httpClient = _clientFactory.CreateClient();
            var urlEncodedAddress = WebUtility.UrlEncode(address);
            var requestUri = $"https://geocoding.geo.census.gov/geocoder/locations/onelineaddress" +
                             $"?address={urlEncodedAddress}&benchmark={benchmark}&vintage={vintage}&format=json";

            var httpResponseMessage = await httpClient.GetAsync(requestUri);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var jsonString = await httpResponseMessage.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<GeocodingResponse>(jsonString);

                return Ok(result);
            }
            else
            {
                return StatusCode((int)httpResponseMessage.StatusCode, httpResponseMessage.ReasonPhrase);
            }
        }
    }
}
