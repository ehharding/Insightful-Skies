using System.Text.Json.Serialization;

namespace InsightfulSkies.Geocoding
{
    public class GeocodingResponse
    {
        [JsonPropertyName("result")]
        public Result? Result { get; set; }
    }

    // See https://geocoding.geo.census.gov/geocoder/Geocoding_Services_API.pdf for the up-to-date schema.
    //
    // {
    //   "result": {
    //     "input": {
    //       "address": {"address": "4600 Silver Hill Rd, Washington, DC 20233"},
    //       "benchmark": {
    //         "isDefault": false,
    //         "benchmarkDescription": "Public Address Ranges - Census 2020 Benchmark",
    //         "id": "2020",
    //         "benchmarkName": "Public_AR_Census2020"
    //       }
    //     },
    //     "addressMatches": [{
    //       "tigerLine": {
    //         "side": "L",
    //         "tigerLineId": "76355984"
    //       },
    //       "coordinates": {
    //         "x": -76.92744,
    //         "y": 38.845985
    //       },
    //       "addressComponents": {
    //         "zip": "20233",
    //         "streetName": "SILVER HILL",
    //         "preType": "",
    //         "city": "WASHINGTON",
    //         "preDirection": "",
    //         "suffixDirection": "",
    //         "fromAddress": "4600",
    //         "state": "DC",
    //         "suffixType": "RD",
    //         "toAddress": "4700",
    //         "suffixQualifier": "",
    //         "preQualifier": ""
    //       },
    //       "matchedAddress": "4600 SILVER HILL RD, WASHINGTON, DC, 20233"
    //     }]
    //   }
    // }
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
