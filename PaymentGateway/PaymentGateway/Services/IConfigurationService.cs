using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Services
{
    public interface IConfigurationService
    {
        string GetBankingApiConfig { get; }
        string GetBankingApiGetConfig { get; }
    }
}
