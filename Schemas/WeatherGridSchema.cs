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

using System.Text.Json.Serialization;

namespace InsightfulSkies.WeatherGrid
{
    /*
     * The WeatherGridResponse class represents the response object returned by the US National Weather Service API
     * endpoint that returns weather grid information for a given latitude and longitude.
     */

    /// <summary>
    ///     <para>
    ///         The <see cref="WeatherGridResponse" /> class represents the response object returned by the US National
    ///     </para>
    ///     <para>
    ///         Weather Service API endpoint that returns weather grid information for a given latitude and longitude.
    ///     </para>
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         This class represents the top-level object returned by the endpoint.
    ///     </para>
    /// </remarks>
    public class WeatherGridResponse
    {
        /*
         * The @context property is an array of objects that provide context for the response. For brevity, this
         * property is not deserialized.
         */
        /// <summary>
        ///     <para>
        ///         The <see cref="Context" /> property is an array of objects that provide context for the response.
        ///     </para>
        ///     <para>
        ///         For brevity, this property is not deserialized.
        ///     </para>
        /// </summary>
        [JsonPropertyName("@context")]
        public object[]? Context { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        /* Unused */
        [JsonPropertyName("geometry")]
        public Object? Geometry { get; set; }

        [JsonPropertyName("properties")]
        public Properties? Properties { get; set; }
    }

    public class Properties
    {
        [JsonPropertyName("@id")]
        public string? Id { get; set; }

        [JsonPropertyName("@type")]
        public string? Type { get; set; }

        [JsonPropertyName("cwa")]
        public string? Cwa { get; set; }

        [JsonPropertyName("forecastOffice")]
        public string? ForecastOffice { get; set; }

        [JsonPropertyName("gridId")]
        public string? GridId { get; set; }

        [JsonPropertyName("gridX")]
        public int? GridX { get; set; }

        [JsonPropertyName("gridY")]
        public int? GridY { get; set; }

        [JsonPropertyName("forecast")]
        public string? Forecast { get; set; }

        [JsonPropertyName("forecastHourly")]
        public string? ForecastHourly { get; set; }

        [JsonPropertyName("forecastGridData")]
        public string? ForecastGridData { get; set; }

        [JsonPropertyName("observationStations")]
        public string? ObservationStations { get; set; }

        /* Unused */
        [JsonPropertyName("relativeLocation")]
        public Object? RelativeLocation { get; set; }

        [JsonPropertyName("forecastZone")]
        public string? ForecastZone { get; set; }

        [JsonPropertyName("county")]
        public string? County { get; set; }

        [JsonPropertyName("fireWeatherZone")]
        public string? FireWeatherZone { get; set; }

        [JsonPropertyName("timeZone")]
        public string? TimeZone { get; set; }

        [JsonPropertyName("radarStation")]
        public string? RadarStation { get; set; }
    }
}
