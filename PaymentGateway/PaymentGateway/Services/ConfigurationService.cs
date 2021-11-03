using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfiguration _configuration;
        public ConfigurationService()
        {

        }
        public ConfigurationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetBankingApiConfig => _configuration.GetSection("BankingApi").Value;
        public string GetBankingApiGetConfig => _configuration.GetSection("BankingApiGet").Value;
    }
}
