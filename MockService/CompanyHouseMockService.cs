﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Onboarding.Api.MockService
{
    public class CompanyHouseMockService
    {
        public CompanyDetails GetCompanyHouseDetailsByName(string companyNameToFind, string companyNumber)
        {

            List<CompanyDetails> companyDetailsList = JsonConvert.DeserializeObject<List<CompanyDetails>>(json);

            var company = SearchCompanies(companyDetailsList,companyNameToFind, companyNumber);
            //CompanyDetails company = companyDetailsList.FirstOrDefault(c => c.CompanyName.Equals(companyNameToFind, StringComparison.OrdinalIgnoreCase));
            return company.FirstOrDefault();
        }

        public CompanyDetails GetCompanyHouseDetailsByNumberNumber(string companyNumberToFind)
        {

            List<CompanyDetails> companyDetailsList = JsonConvert.DeserializeObject<List<CompanyDetails>>(json);

            CompanyDetails company = companyDetailsList.FirstOrDefault(c => c.CompanyNumber.Equals(companyNumberToFind, StringComparison.OrdinalIgnoreCase));
            return company;
        }


        public  List<CompanyDetails> SearchCompanies(List<CompanyDetails> companies, string companyName, string companyNumber)
        {
            return companies
                .Where(c => c.CompanyName.Contains(companyName, StringComparison.OrdinalIgnoreCase) &&
                            WildcardMatch(c.CompanyNumber, companyNumber))
                .ToList();
        }
        public static bool WildcardMatch(string input, string pattern)
        {
            pattern = "^" + System.Text.RegularExpressions.Regex.Escape(pattern).Replace("\\*", ".*").Replace("\\?", ".") + "$";
            return System.Text.RegularExpressions.Regex.IsMatch(input, pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        }


        #region

        string json = @" [
  {
    ""company_name"": ""Tenpin Ltd."",
    ""company_number"": ""04789703"",
    ""incorporation_date"": ""2023-01-15"",
    ""company_status"": ""active"",
    ""registered_office_address"": {
      ""address_line_1"": ""123 Main Street"",
      ""address_line_2"": ""Unit 1"",
      ""locality"": ""London"",
      ""postal_code"": ""OX16 4UT"",
      ""country"": ""United Kingdom""
    },
    ""accounts"": {
      ""next_due"": ""2024-12-31"",
      ""last_accounts"": {
        ""period_start_date"": ""2022-01-01"",
        ""period_end_date"": ""2022-12-31"",
        ""type"": ""full""
      }
    },
    ""directors"": [
      {
        ""name"": ""John Smith"",
        ""date_of_birth"": ""1980-05-15"",
        ""nationality"": ""British"",
        ""occupation"": ""Director""
      },
      {
        ""name"": ""Jane Doe"",
        ""date_of_birth"": ""1975-08-20"",
        ""nationality"": ""British"",
        ""occupation"": ""Director""
      }
    ],
    ""persons_with_significant_control"": [
      {
        ""name"": ""Michael Brown"",
        ""date_of_birth"": ""1970-12-10"",
        ""nationality"": ""British"",
        ""natures_of_control"": [ ""ownership"" ],
        ""address"": {
          ""address_line_1"": ""456 High Street"",
          ""locality"": ""Manchester"",
          ""postal_code"": ""M1 1AB"",
          ""country"": ""United Kingdom""
        }
      }
    ]
  },
  {
    ""company_name"": ""Sample Enterprises Inc"",
    ""company_number"": ""98765432"",
    ""incorporation_date"": ""2020-07-20"",
    ""company_status"": ""active"",
    ""registered_office_address"": {
      ""address_line_1"": ""789 Oak Avenue"",
      ""locality"": ""London"",
      ""postal_code"": ""W1J 5BX"",
      ""country"": ""United Kingdom""
    },
    ""accounts"": {
      ""next_due"": ""2023-07-20"",
      ""last_accounts"": {
        ""period_start_date"": ""2022-01-01"",
        ""period_end_date"": ""2022-12-31"",
        ""type"": ""full""
      }
    },
    ""directors"": [
      {
        ""name"": ""Emily Johnson"",
        ""date_of_birth"": ""1985-09-25"",
        ""nationality"": ""British"",
        ""occupation"": ""CEO""
      },
      {
        ""name"": ""Mark Anderson"",
        ""date_of_birth"": ""1978-04-12"",
        ""nationality"": ""British"",
        ""occupation"": ""CFO""
      }
    ],
    ""persons_with_significant_control"": [
      {
        ""name"": ""Emily Johnson"",
        ""date_of_birth"": ""1985-09-25"",
        ""nationality"": ""British"",
        ""natures_of_control"": [ ""ownership"" ],
        ""address"": {
          ""address_line_1"": ""789 Oak Avenue"",
          ""locality"": ""London"",
          ""postal_code"": ""W1J 5BX"",
          ""country"": ""United Kingdom""
        }
      }
    ]
  },
  {
    ""company_name"": ""Tech Solutions Ltd"",
    ""company_number"": ""24681012"",
    ""incorporation_date"": ""2018-03-10"",
    ""company_status"": ""active"",
    ""registered_office_address"": {
      ""address_line_1"": ""567 Maple Street"",
      ""locality"": ""Edinburgh"",
      ""postal_code"": ""EH1 1YZ"",
      ""country"": ""United Kingdom""
    },
    ""accounts"": {
      ""next_due"": ""2023-03-10"",
      ""last_accounts"": {
        ""period_start_date"": ""2022-01-01"",
        ""period_end_date"": ""2022-12-31"",
        ""type"": ""full""
      }
    },
    ""directors"": [
      {
        ""name"": ""David Brown"",
        ""date_of_birth"": ""1982-11-30"",
        ""nationality"": ""British"",
        ""occupation"": ""CTO""
      },
      {
        ""name"": ""Sarah Miller"",
        ""date_of_birth"": ""1976-06-18"",
        ""nationality"": ""British"",
        ""occupation"": ""COO""
      }
    ],
    ""persons_with_significant_control"": [
      {
        ""name"": ""David Brown"",
        ""date_of_birth"": ""1982-11-30"",
        ""nationality"": ""British"",
        ""natures_of_control"": [ ""ownership"" ],
        ""address"": {
          ""address_line_1"": ""567 Maple Street"",
          ""locality"": ""Edinburgh"",
          ""postal_code"": ""EH1 1YZ"",
          ""country"": ""United Kingdom""
        }
      }
    ]
  },
  {
    ""company_name"": ""Global Trading Co."",
    ""company_number"": ""13579246"",
    ""incorporation_date"": ""2015-09-05"",
    ""company_status"": ""active"",
    ""registered_office_address"": {
      ""address_line_1"": ""101 Commerce Blvd"",
      ""locality"": ""Birmingham"",
      ""postal_code"": ""B1 1AA"",
      ""country"": ""United Kingdom""
    },
    ""accounts"": {
      ""next_due"": ""2023-09-05"",
      ""last_accounts"": {
        ""period_start_date"": ""2022-01-01"",
        ""period_end_date"": ""2022-12-31"",
        ""type"": ""full""
      }
    },
    ""directors"": [
      {
        ""name"": ""Alex Wong"",
        ""date_of_birth"": ""1970-03-12"",
        ""nationality"": ""British"",
        ""occupation"": ""CEO""
      },
      {
        ""name"": ""Sophie Lee"",
        ""date_of_birth"": ""1983-07-28"",
        ""nationality"": ""British"",
        ""occupation"": ""CFO""
      }
    ],
    ""persons_with_significant_control"": [
      {
        ""name"": ""Alex Wong"",
        ""date_of_birth"": ""1970-03-12"",
        ""nationality"": ""British"",
        ""natures_of_control"": [ ""ownership"" ],
        ""address"": {
          ""address_line_1"": ""101 Commerce Blvd"",
          ""locality"": ""Birmingham"",
          ""postal_code"": ""B1 1AA"",
          ""country"": ""United Kingdom""
        }
      }
    ]
  },
  {
    ""company_name"": ""Medical Supplies Ltd"",
    ""company_number"": ""11223344"",
    ""incorporation_date"": ""2019-05-12"",
    ""company_status"": ""active"",
    ""registered_office_address"": {
      ""address_line_1"": ""321 Health Street"",
      ""locality"": ""Glasgow"",
      ""postal_code"": ""G1 1AB"",
      ""country"": ""United Kingdom""
    },
    ""accounts"": {
      ""next_due"": ""2023-05-12"",
      ""last_accounts"": {
        ""period_start_date"": ""2022-01-01"",
        ""period_end_date"": ""2022-12-31"",
        ""type"": ""full""
      }
    },
    ""directors"": [
      {
        ""name"": ""Emma Green"",
        ""date_of_birth"": ""1987-12-05"",
        ""nationality"": ""British"",
        ""occupation"": ""CEO""
      },
      {
        ""name"": ""Michael Johnson"",
        ""date_of_birth"": ""1975-02-18"",
        ""nationality"": ""British"",
        ""occupation"": ""CFO""
      }
    ],
    ""persons_with_significant_control"": [
      {
        ""name"": ""Emma Green"",
        ""date_of_birth"": ""1987-12-05"",
        ""nationality"": ""British"",
        ""natures_of_control"": [ ""ownership"" ],
        ""address"": {
          ""address_line_1"": ""321 Health Street"",
          ""locality"": ""Glasgow"",
          ""postal_code"": ""G1 1AB"",
          ""country"": ""United Kingdom""
        }
      }
    ]
  },
  {
    ""company_name"": ""Design Studio Ltd"",
    ""company_number"": ""87654321"",
    ""incorporation_date"": ""2017-11-18"",
    ""company_status"": ""active"",
    ""registered_office_address"": {
      ""address_line_1"": ""456 Art Avenue"",
      ""locality"": ""Cardiff"",
      ""postal_code"": ""CF10 2AB"",
      ""country"": ""United Kingdom""
    },
    ""accounts"": {
      ""next_due"": ""2023-11-18"",
      ""last_accounts"": {
        ""period_start_date"": ""2022-01-01"",
        ""period_end_date"": ""2022-12-31"",
        ""type"": ""full""
      }
    },
    ""directors"": [
      {
        ""name"": ""Daniel White"",
        ""date_of_birth"": ""1984-08-10"",
        ""nationality"": ""British"",
        ""occupation"": ""CEO""
      },
      {
        ""name"": ""Olivia Brown"",
        ""date_of_birth"": ""1979-05-22"",
        ""nationality"": ""British"",
        ""occupation"": ""CFO""
      }
    ],
    ""persons_with_significant_control"": [
      {
        ""name"": ""Daniel White"",
        ""date_of_birth"": ""1984-08-10"",
        ""nationality"": ""British"",
        ""natures_of_control"": [ ""ownership"" ],
        ""address"": {
          ""address_line_1"": ""456 Art Avenue"",
          ""locality"": ""Cardiff"",
          ""postal_code"": ""CF10 2AB"",
          ""country"": ""United Kingdom""
        }
      }
    ]
  },
  {
    ""company_name"": ""Finance Solutions Inc"",
    ""company_number"": ""98765432"",
    ""incorporation_date"": ""2016-04-03"",
    ""company_status"": ""active"",
    ""registered_office_address"": {
      ""address_line_1"": ""789 Finance Street"",
      ""locality"": ""London"",
      ""postal_code"": ""W1S 1LA"",
      ""country"": ""United Kingdom""
    },
    ""accounts"": {
      ""next_due"": ""2023-04-03"",
      ""last_accounts"": {
        ""period_start_date"": ""2022-01-01"",
        ""period_end_date"": ""2022-12-31"",
        ""type"": ""full""
      }
    },
    ""directors"": [
      {
        ""name"": ""Thomas Johnson"",
        ""date_of_birth"": ""1976-09-15"",
        ""nationality"": ""British"",
        ""occupation"": ""CEO""
      },
      {
        ""name"": ""Sophia Anderson"",
        ""date_of_birth"": ""1980-11-28"",
        ""nationality"": ""British"",
        ""occupation"": ""CFO""
      }
    ],
    ""persons_with_significant_control"": [
      {
        ""name"": ""Thomas Johnson"",
        ""date_of_birth"": ""1976-09-15"",
        ""nationality"": ""British"",
        ""natures_of_control"": [ ""ownership"" ],
        ""address"": {
          ""address_line_1"": ""789 Finance Street"",
          ""locality"": ""London"",
          ""postal_code"": ""W1S 1LA"",
          ""country"": ""United Kingdom""
        }
      }
    ]
  },
  {
    ""company_name"": ""Consultancy Services Ltd"",
    ""company_number"": ""11223344"",
    ""incorporation_date"": ""2019-08-21"",
    ""company_status"": ""active"",
    ""registered_office_address"": {
      ""address_line_1"": ""456 Consulting Avenue"",
      ""locality"": ""Liverpool"",
      ""postal_code"": ""L1 2AB"",
      ""country"": ""United Kingdom""
    },
    ""accounts"": {
      ""next_due"": ""2023-08-21"",
      ""last_accounts"": {
        ""period_start_date"": ""2022-01-01"",
        ""period_end_date"": ""2022-12-31"",
        ""type"": ""full""
      }
    },
    ""directors"": [
      {
        ""name"": ""Jessica Taylor"",
        ""date_of_birth"": ""1983-04-30"",
        ""nationality"": ""British"",
        ""occupation"": ""CEO""
      },
      {
        ""name"": ""Robert Green"",
        ""date_of_birth"": ""1975-11-17"",
        ""nationality"": ""British"",
        ""occupation"": ""CFO""
      }
    ],
    ""persons_with_significant_control"": [
      {
        ""name"": ""Jessica Taylor"",
        ""date_of_birth"": ""1983-04-30"",
        ""nationality"": ""British"",
        ""natures_of_control"": [ ""ownership"" ],
        ""address"": {
          ""address_line_1"": ""456 Consulting Avenue"",
          ""locality"": ""Liverpool"",
          ""postal_code"": ""L1 2AB"",
          ""country"": ""United Kingdom""
        }
      }
    ]
  },
  {
    ""company_name"": ""Energy Solutions Inc"",
    ""company_number"": ""99887766"",
    ""incorporation_date"": ""2014-03-15"",
    ""company_status"": ""active"",
    ""registered_office_address"": {
      ""address_line_1"": ""123 Energy Street"",
      ""locality"": ""Bristol"",
      ""postal_code"": ""BS1 1AB"",
      ""country"": ""United Kingdom""
    },
    ""accounts"": {
      ""next_due"": ""2023-03-15"",
      ""last_accounts"": {
        ""period_start_date"": ""2022-01-01"",
        ""period_end_date"": ""2022-12-31"",
        ""type"": ""full""
      }
    },
    ""directors"": [
      {
        ""name"": ""Andrew Thompson"",
        ""date_of_birth"": ""1972-07-08"",
        ""nationality"": ""British"",
        ""occupation"": ""CEO""
      },
      {
        ""name"": ""Emily Wilson"",
        ""date_of_birth"": ""1980-02-14"",
        ""nationality"": ""British"",
        ""occupation"": ""CFO""
      }
    ],
    ""persons_with_significant_control"": [
      {
        ""name"": ""Andrew Thompson"",
        ""date_of_birth"": ""1972-07-08"",
        ""nationality"": ""British"",
        ""natures_of_control"": [ ""ownership"" ],
        ""address"": {
          ""address_line_1"": ""123 Energy Street"",
          ""locality"": ""Bristol"",
          ""postal_code"": ""BS1 1AB"",
          ""country"": ""United Kingdom""
        }
      }
    ]
  },
  {
    ""company_name"": ""Retail Solutions Ltd"",
    ""company_number"": ""33445566"",
    ""incorporation_date"": ""2016-11-30"",
    ""company_status"": ""active"",
    ""registered_office_address"": {
      ""address_line_1"": ""789 Retail Avenue"",
      ""locality"": ""Manchester"",
      ""postal_code"": ""M2 4AB"",
      ""country"": ""United Kingdom""
    },
    ""accounts"": {
      ""next_due"": ""2023-11-30"",
      ""last_accounts"": {
        ""period_start_date"": ""2022-01-01"",
        ""period_end_date"": ""2022-12-31"",
        ""type"": ""full""
      }
    },
    ""directors"": [
      {
        ""name"": ""Sophie Brown"",
        ""date_of_birth"": ""1986-05-20"",
        ""nationality"": ""British"",
        ""occupation"": ""CEO""
      },
      {
        ""name"": ""William Davis"",
        ""date_of_birth"": ""1979-08-08"",
        ""nationality"": ""British"",
        ""occupation"": ""CFO""
      }
    ],
    ""persons_with_significant_control"": [
      {
        ""name"": ""Sophie Brown"",
        ""date_of_birth"": ""1986-05-20"",
        ""nationality"": ""British"",
        ""natures_of_control"": [ ""ownership"" ],
        ""address"": {
          ""address_line_1"": ""789 Retail Avenue"",
          ""locality"": ""Manchester"",
          ""postal_code"": ""M2 4AB"",
          ""country"": ""United Kingdom""
        }
      }
    ]
  }
]";

        #endregion
    }
}
