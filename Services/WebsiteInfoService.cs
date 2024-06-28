using Newtonsoft.Json;
using Onboarding.Api.Requests;
using Onboarding.Api.Response;

namespace Onboarding.Api.Services
{
    public class WebsiteInfoService
    {
        private readonly OpenAIService1 _openAIService1;
        private List<ChatMessage> _messages;
        public WebsiteInfoService(OpenAIService1 openAIService1)
        {
            _openAIService1 = openAIService1;
            _messages = _messages = new List<ChatMessage>(); ;
        }



        public async Task<WebsiteInfo> GetSiteInfo(string url) 
        {
            string json = @"{
  ""company_name"": ""Company Name Here"",
  ""company_number"": ""04789703"",
    ""industry_sector"": ""Industry or Sector Here"",
""sic"": ""93290"",
  ""company_size"": {
    ""number_of_employees"": ""Approximate number of employees here"",
    ""revenue"": ""Approximate annual revenue here""
  },
  ""location"": {
    ""headquarters"": {
      ""address_line_1"": ""Headquarters address line 1 here"",
      ""locality"": ""Locality here"",
      ""postal_code"": ""Postal code here"",
      ""country"": ""Country here""
    }
  }
}";
            var promptMessage = $"Please enrich the data for the following business website:{url} by providing the following information in JSON format:\r\nCompany Name:\r\n Company number , Verify and standardize the official company name.\r\nIndustry/Sector:\r\nDetermine the industry or sector and Nature of Business (SIC) the business operates in using keyword analysis and business directories.\r\nCompany Size:\r\nEstimate the size of the company, including:\r\nNumber of Employees: Use web content, job postings, and LinkedIn data for estimation.\r\nRevenue: Provide an approximate annual revenue based on industry standards and available financial information.\r\nLocation:\r\nEnrich with geolocation data to determine the headquarters and other office locations.\r\nProvide the information in the following JSON format:{json}";
            _messages.Add(new ChatMessage()
            {
                Role = "user",
                Content = promptMessage
            });

            try
            {
                var jsonResponse = await _openAIService1.GenerateChatCompletion(_messages);

                WebsiteInfo websiteInfo = JsonConvert.DeserializeObject<WebsiteInfo>(jsonResponse);
                return websiteInfo;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }
    }
}
