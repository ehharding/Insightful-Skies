using System.Text.Json.Serialization;

namespace InsightfulSkies.Geocoding
{
    public class GeocodingResponse
    {
        [JsonPropertyName("result")]
        public Result? Result { get; set; }
    }

    public class Result
    {
        [JsonPropertyName("input")]
        public Input? Input { get; set; }

        [JsonPropertyName("addressMatches")]
        public AddressMatch[]? AddressMatches { get; set; }
    }

    public class Input
    {
        [JsonPropertyName("address")]
        public Address? Address { get; set; }

        [JsonPropertyName("benchmark")]
        public Benchmark? Benchmark { get; set; }
    }

    public class Address
    {
        [JsonPropertyName("address")]
        public string? AddressString { get; set; }
    }

    public class Benchmark
    {
        [JsonPropertyName("isDefault")]
        public bool? IsDefault { get; set; }

        [JsonPropertyName("benchmarkDescription")]
        public string? BenchmarkDescription { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("benchmarkName")]
        public string? BenchmarkName { get; set; }
    }

    public class AddressMatch
    {
        [JsonPropertyName("tigerLine")]
        public TigerLine? TigerLine { get; set; }

        [JsonPropertyName("coordinates")]
        public Coordinates? Coordinates { get; set; }

        [JsonPropertyName("addressComponents")]
        public AddressComponents? AddressComponents { get; set; }

        [JsonPropertyName("matchedAddress")]
        public string? MatchedAddress { get; set; }
    }

    public class TigerLine
    {
        [JsonPropertyName("side")]
        public string? Side { get; set; }

        [JsonPropertyName("tigerLineId")]
        public string? TigerLineId { get; set; }
    }

    public class Coordinates
    {
        [JsonPropertyName("x")]
        public double? X { get; set; }

        [JsonPropertyName("y")]
        public double? Y { get; set; }
    }

    public class AddressComponents
    {
        [JsonPropertyName("zip")]
        public string? Zip { get; set; }

        [JsonPropertyName("streetName")]
        public string? StreetName { get; set; }

        [JsonPropertyName("preType")]
        public string? PreType { get; set; }

        [JsonPropertyName("city")]
        public string? City { get; set; }

        [JsonPropertyName("preDirection")]
        public string? PreDirection { get; set; }

        [JsonPropertyName("suffixDirection")]
        public string? SuffixDirection { get; set; }

        [JsonPropertyName("fromAddress")]
        public string? FromAddress { get; set; }

        [JsonPropertyName("state")]
        public string? State { get; set; }

        [JsonPropertyName("suffixType")]
        public string? SuffixType { get; set; }

        [JsonPropertyName("toAddress")]
        public string? ToAddress { get; set; }

        [JsonPropertyName("suffixQualifier")]
        public string? SuffixQualifier { get; set; }

        [JsonPropertyName("preQualifier")]
        public string? PreQualifier { get; set; }
    }
}
