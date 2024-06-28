using Newtonsoft.Json;
using Onboarding.Api.MockService;
using Onboarding.Api.Requests;
using Onboarding.Api.Response;
using System.Drawing;
using System.Numerics;
using System.Reflection;

namespace Onboarding.Api.Services
{
    public class OnboardingService
    {
        private readonly OpenAIService1 _openAIService1;
        private readonly BusinessRevenueService _businessRevenueService;
        private readonly CompanyHouseMockService _companyHouseMockService;
        private readonly WebsiteInfoService _websiteInfoService;
        private readonly MccMockService _mccMockService;
        private List<ChatMessage> _messages;
        private CompanyDetails _company;
        private WebsiteInfo _websiteInfo;
        public OnboardingService(OpenAIService1 openAIService, BusinessRevenueService businessRevenueService, MccMockService mccMockService, CompanyHouseMockService companyHouseMockService, WebsiteInfoService websiteInfoService)
        {
            _openAIService1 = openAIService;
            _businessRevenueService = businessRevenueService;
            _companyHouseMockService = companyHouseMockService;
            _websiteInfoService = websiteInfoService;
            _mccMockService = mccMockService;
            _messages = new List<ChatMessage>();
        }
        public async Task<ProductResponse> GetOnBoardingSummary(OnboardingRequest request)
        {
            // Construct the Prompt using request fields

            _websiteInfo = await _websiteInfoService.GetSiteInfo(request.BusinessUrl);
            _company = _companyHouseMockService.GetCompanyHouseDetailsByName(_websiteInfo.CompanyName, _websiteInfo.Location.Headquarters.PostalCode);
            _company = _companyHouseMockService.GetCompanyHouseDetailsByNumberNumber(request.BusinessUrl);



            //string companySize = _businessRevenueService.GetCompanySize(request.AnnualTurnOver);
            int mccCode= _mccMockService.GetMockMccCode();


            var promptText = $"﻿Given following products\r\n \r\nTap to Pay:" +
                $" This product allows you to take contactless payments directly" +
                $" through your smartphone without any additional hardware. " +
                $"It is ideal for small and medium-sized merchants with revenue over £10,000 who conduct face-to-face transactions." +
                $" It supports both iPhone and Android devices and ensures secure " +
                $"transactions through built-in device protections and " +
                $"Tyl's security standards​.\r\n\r\nClover Flex: An all-in-one POS system that helps manage business operations on the go." +
                $" It includes features for employee and inventory management, as well as printing and splitting bills. " +
                $"Connectivity options include 4G and Wi-Fi​​. Ideal for small and medium businesses.\r\n\r\nPAX A50: " +
                $"A pocket-sized, portable card machine ideal for businesses needing mobility. It supports Wi-Fi, 4G, and Bluetooth " +
                $"connectivity​​. Ideal for small and medium businesses.\r\n\r\nIngenico Desk 3500: A countertop card machine" +
                $" that remains stationary and is connected via Ethernet. It's suitable for businesses with a fixed payment point​." +
                $" Ideal for small and medium businesses.\r\n\r\nIngenico Move 3500: A portable card machine designed" +
                $" for taking payments on the move, connected through Wi-Fi and 4G​​. Ideal for small and " +
                $"medium businesses.\r\n\r\nPayment Links: Allows businesses to send secure online payment links to customers," +
                $" which can be convenient for receiving payments without a physical POS terminal. " +
                $"This method is beneficial for businesses that send invoices or " +
                $"operate remotely​.\r\n\r\nVirtual Terminal: Enables taking payments over the phone or through online portals," +
                $" ensuring flexibility and security for remote transactions​​.\r\n\r\nPayment Gateway: Supports integration with websites" +
                $" for seamless online payment processing, ensuring PCI compliance and fraud protection​​.\r\n\r\nAnd" +
                $" following historical transaction list\r\n{{\r\n  \"transactions\": [\r\n    {{\"amount\": 24.75, \"mcc\": \"8263\", \"category\": \"bakery\", \"transaction_id\": \"txn001\", \"date\": \"2024-01-01\"}},\r\n   " +
                $" {{\"amount\": 35.00, \"mcc\": \"8263\", \"category\": \"bakery\", \"transaction_id\": \"txn002\", \"date\": \"2024-01-02\"}},\r\n    {{\"amount\": 42.50, \"mcc\": \"8263\", \"category\": \"bakery\", \"transaction_id\": \"txn003\", \"date\": \"2024-01-03\"}},\r\n   " +
                $" {{\"amount\": 18.90, \"mcc\": \"9274\", \"category\": \"dentist\", \"transaction_id\": \"txn004\", \"date\": \"2024-01-04\"}},\r\n    {{\"amount\": 55.20, \"mcc\": \"9274\", \"category\": \"dentist\", \"transaction_id\": \"txn005\", \"date\": \"2024-01-05\"}},\r\n    {{\"amount\": 28.00, \"mcc\": \"9274\", \"category\": \"dentist\", \"transaction_id\": \"txn006\", \"date\": \"2024-01-06\"}},\r\n    {{\"amount\": 37.15, \"mcc\": \"7384\", \"category\": \"plumber\", \"transaction_id\": \"txn007\", \"date\": \"2024-01-07\"}},\r\n    {{\"amount\": 44.80, \"mcc\": \"7384\", \"category\": \"plumber\", \"transaction_id\": \"txn008\", \"date\": \"2024-01-08\"}},\r\n    {{\"amount\": 50.00, \"mcc\": \"7384\", \"category\": \"plumber\", \"transaction_id\": \"txn009\", \"date\": \"2024-01-09\"}},\r\n    {{\"amount\": 21.35, \"mcc\": \"7384\", \"category\": \"plumber\", \"transaction_id\": \"txn010\", \"date\": \"2024-01-10\"}}\r\n  ]\r\n}}\r\n\r\nPromotions offered\r\n\r\nMerchants based in Locations Watford and Manchester receive 10% discount for 3 months.\r\n\r\nMerchants based in Locations London and Luton receive 15% discount 1st month.\r\n\r\nMerchants with average transaction amount greater than 50 get 1% discount for 12 months.\r\n\r\n\r\n";


            var outPutText = $"using System.Collections.Generic;\r\nusing Newtonsoft.Json;\r\nnamespace Onboarding.Api.Response\r\n{{\r\n    public class SuitableProduct\r\n    {{\r\n        [JsonProperty(\"product_name\")]\r\n        public string ProductName {{ get; set; }}\r\n        [JsonProperty(\"description\")]\r\n        public string Description {{ get; set; }}\r\n        [JsonProperty(\"reasoning\")]\r\n        public string Reasoning {{ get; set; }}\r\n    }}\r\n    public class Promotion\r\n    {{\r\n        [JsonProperty(\"promotion_type\")]\r\n        public string PromotionType {{ get; set; }}\r\n        [JsonProperty(\"description\")]\r\n        public string Description {{ get; set; }}\r\n        [JsonProperty(\"discount_percent\")]\r\n        public string DiscountPercent {{ get; set; }}\r\n    }}\r\n    public class ProductResponse\r\n    {{\r\n        [JsonProperty(\"suitable_products\")]\r\n        public List<SuitableProduct> SuitableProducts {{ get; set; }}\r\n        [JsonProperty(\"applicable_promotions\")]\r\n        public List<Promotion> ApplicablePromotions {{ get; set; }}\r\n        [JsonProperty(\"historical_average_transaction_amount\")]\r\n        public string HistoricalAverageTransactionAmount {{ get; set; }}\r\n        [JsonProperty(\"why_products_suitable\")]\r\n        public string WhyProductsSuitable {{ get; set; }}\r\n        [JsonProperty(\"Industry_Sector\")]\r\n        public string IndustrySector {{ get; set; }}\r\n        [JsonProperty(\"Sic\")]\r\n        public string SIC {{ get; set; }}\r\n    }}\r\n}}";
           
            var promptMessage = $"promptText" +
                $"My company belongs to industry {_websiteInfo.IndustrySector} with annual turnover of {_websiteInfo.CompanySize.Revenue} and taking payments face to face payments and online payments.\r\n Recommend me suitable product list, applicable promotions and historical average transaction amount in JSON format with suitable_products, discounts and why this products are suitable for business as suitable, I want the json format in this format to deserialise {outPutText} ";

            _messages.Add(new ChatMessage()
            {
                Role= "user",
                Content = promptMessage
            });

            try
            {

                var content = await _openAIService1.GenerateChatCompletion(_messages); 
                return JsonConvert.DeserializeObject<ProductResponse>(content);
                var result = await _openAIService1.GenerateChatCompletion(_messages);

                var deserializedObject = JsonConvert.DeserializeObject<ProductResponse>(result);
                return deserializedObject;

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        

        //private static string GetPromptText()
        //{
        //    FileInfo _file = new FileInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "//Prompts//MainPrompt.txt");

        //    if (_file.Exists)
        //    {
        //        using var reader = _file.OpenText();
        //        return reader.ReadToEnd();
        //    }

        //    return "Bla";
        //}

        //public string GetRefinedPrompt(string category, string[] options, string plans)
        //{
        //    var promptText = GetPromptText();

        //    // Replace
        //    var businessInfo = Mocks.LastYearTurnoverFromCompanyHouse();
        //    promptText = promptText
        //        .Replace(SIZE, businessInfo.Item1)
        //        .Replace(TURN_OVER, businessInfo.Item2.ToString("c"))
        //        .Replace(CATEGORY, category)
        //        .Replace(LOCATIONS, Mocks.GetLocationsText())
        //        .Replace(AVERAGE, Mocks.GetAverageTransactionValue().ToString("c"))
        //        .Replace(HOW, string.Join(JoinerWithSpace, options));

        //    if (!string.IsNullOrWhiteSpace(plans))
        //    {
        //        promptText = promptText.Replace(PLAN, plans);
        //    }

        //    return promptText;
        //}
    }
}
