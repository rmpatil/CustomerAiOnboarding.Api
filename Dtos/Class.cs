using Newtonsoft.Json;
using System;
using System.Collections.Generic;
public class RegisteredOfficeAddress
{
    [JsonProperty("address_line_1")]
    public string AddressLine1 { get; set; }
    [JsonProperty("address_line_2")]
    public string AddressLine2 { get; set; }
    [JsonProperty("locality")]
    public string Locality { get; set; }
    [JsonProperty("postal_code")]
    public string PostalCode { get; set; }
    [JsonProperty("country")]
    public string Country { get; set; }
}
public class LastAccounts
{
    [JsonProperty("period_start_date")]
    public DateTime PeriodStartDate { get; set; }
    [JsonProperty("period_end_date")]
    public DateTime PeriodEndDate { get; set; }
    [JsonProperty("type")]
    public string Type { get; set; }
}
public class Accounts
{
    [JsonProperty("next_due")]
    public DateTime NextDue { get; set; }
    [JsonProperty("last_accounts")]
    public LastAccounts LastAccounts { get; set; }
}
public class Director
{
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("date_of_birth")]
    public DateTime DateOfBirth { get; set; }
    [JsonProperty("nationality")]
    public string Nationality { get; set; }
    [JsonProperty("occupation")]
    public string Occupation { get; set; }
}
public class PersonWithSignificantControl
{
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("date_of_birth")]
    public DateTime DateOfBirth { get; set; }
    [JsonProperty("nationality")]
    public string Nationality { get; set; }
    [JsonProperty("natures_of_control")]
    public List<string> NaturesOfControl { get; set; }
    [JsonProperty("address")]
    public RegisteredOfficeAddress Address { get; set; }
}
public class CompanyDetails
{
    [JsonProperty("company_name")]
    public string CompanyName { get; set; }
    [JsonProperty("company_number")]
    public string CompanyNumber { get; set; }
    [JsonProperty("incorporation_date")]
    public DateTime IncorporationDate { get; set; }
    [JsonProperty("company_status")]
    public string CompanyStatus { get; set; }
    [JsonProperty("registered_office_address")]
    public RegisteredOfficeAddress RegisteredOfficeAddress { get; set; }
    [JsonProperty("accounts")]
    public Accounts Accounts { get; set; }
    [JsonProperty("directors")]
    public List<Director> Directors { get; set; }
    [JsonProperty("persons_with_significant_control")]
    public List<PersonWithSignificantControl> PersonsWithSignificantControl { get; set; }
}