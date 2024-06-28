using System;
using System.Net;
using Newtonsoft.Json;
public class WebsiteInfo
{
        [JsonProperty("company_name")]
        public string CompanyName { get; set; }
        [JsonProperty("industry_sector")]
        public string IndustrySector { get; set; }
        [JsonProperty("company_number")]
        public string CompanyNumber { get; set; }
    [JsonProperty("sic")]
    public string Sic { get; set; }
    [JsonProperty("company_size")]
        public CompanySize CompanySize { get; set; }
        [JsonProperty("location")]
        public Location Location { get; set; }
    }
    public class CompanySize
    {
        [JsonProperty("number_of_employees")]
        public string NumberOfEmployees { get; set; }
        [JsonProperty("revenue")]
        public string Revenue { get; set; }
    }
    public class Location
    {
        [JsonProperty("headquarters")]
        public Address Headquarters { get; set; }
    }
    public class Address
    {
        [JsonProperty("address_line_1")]
        public string AddressLine1 { get; set; }
        [JsonProperty("locality")]
        public string Locality { get; set; }
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
    }