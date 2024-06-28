using System.Collections.Generic;
using Newtonsoft.Json;
namespace Onboarding.Api.Response
{
    public class SuitableProduct
    {
        [JsonProperty("product_name")]
        public string ProductName { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("reasoning")]
        public string Reasoning { get; set; }
    }
    public class Promotion
    {
        [JsonProperty("promotion_type")]
        public string PromotionType { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("discount_percent")]
        public string DiscountPercent { get; set; }
    }
    public class ProductResponse
    {
        [JsonProperty("suitable_products")]
        public List<SuitableProduct> SuitableProducts { get; set; }
        [JsonProperty("applicable_promotions")]
        public List<Promotion> ApplicablePromotions { get; set; }
        [JsonProperty("historical_average_transaction_amount")]
        public string HistoricalAverageTransactionAmount { get; set; }
        [JsonProperty("why_products_suitable")]
        public string WhyProductsSuitable { get; set; }
        [JsonProperty("Industry_Sector")]
        public string IndustrySector { get; set; }
        [JsonProperty("Sic")]
        public string SIC { get; set; }
    }
}