using System.Text.Json.Serialization;

namespace InsightfulSkies.WeatherGrid
{
    public class WeatherGridResponse
    {
        /* Unused */
        [JsonPropertyName("@context")]
        public Object[]? Context { get; set; }

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
