using System.Text.Json.Serialization;

namespace InsightfulSkies.WeatherForecast
{
    public class WeatherForecastResponse
    {
        /* Unused */
        [JsonPropertyName("@context")]
        public Object[]? Context { get; set; }

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
        [JsonPropertyName("updated")]
        public string? Updated { get; set; }

        [JsonPropertyName("units")]
        public string? Units { get; set; }

        [JsonPropertyName("forecastGenerator")]
        public string? ForecastGenerator { get; set; }

        [JsonPropertyName("generatedAt")]
        public string? GeneratedAt { get; set; }

        [JsonPropertyName("updateTime")]
        public string? UpdateTime { get; set; }

        [JsonPropertyName("validTimes")]
        public string? ValidTimes { get; set; }

        [JsonPropertyName("elevation")]
        public Elevation? Elevation { get; set; }

        [JsonPropertyName("periods")]
        public Period[]? Periods { get; set; }
    }

    public class Elevation
    {
        [JsonPropertyName("unitCode")]
        public string? UnitCode { get; set; }

        [JsonPropertyName("value")]
        public double? Value { get; set; }
    }

    public class Period
    {
        [JsonPropertyName("number")]
        public int? Number { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("startTime")]
        public string? StartTime { get; set; }

        [JsonPropertyName("endTime")]
        public string? EndTime { get; set; }

        [JsonPropertyName("isDaytime")]
        public bool? IsDaytime { get; set; }

        [JsonPropertyName("temperature")]
        public int? Temperature { get; set; }

        [JsonPropertyName("temperatureUnit")]
        public string? TemperatureUnit { get; set; }

        [JsonPropertyName("temperatureTrend")]
        public string? TemperatureTrend { get; set; }

        [JsonPropertyName("probabilityOfPrecipitation")]
        public ProbabilityOfPrecipitation? ProbabilityOfPrecipitation { get; set; }

        [JsonPropertyName("relativeHumidity")]
        public RelativeHumidity? RelativeHumidity { get; set; }

        [JsonPropertyName("windSpeed")]
        public string? WindSpeed { get; set; }

        [JsonPropertyName("icon")]
        public string? Icon { get; set; }

        [JsonPropertyName("shortForecast")]
        public string? ShortForecast { get; set; }

        [JsonPropertyName("detailedForecast")]
        public string? DetailedForecast { get; set; }
    }

    public class ProbabilityOfPrecipitation
    {
        [JsonPropertyName("unitCode")]
        public string? UnitCode { get; set; }

        [JsonPropertyName("value")]
        public int? Value { get; set; }
    }

    public class RelativeHumidity
    {
        [JsonPropertyName("unitCode")]
        public string? UnitCode { get; set; }

        [JsonPropertyName("value")]
        public int? Value { get; set; }
    }
}
