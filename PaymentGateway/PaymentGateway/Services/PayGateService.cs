using Newtonsoft.Json;
using PaymentGateway.Models;
using PaymentGateway.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Services
{
    public class PayGateService : IPayGateService
    {
        private readonly IRestClient _restclient;
        private readonly IConfigurationService _configurationService;
        private string url = "https://api.checkout.com/payments";
        public PayGateService(IRestClient restclient,IConfigurationService configurationService)
        {
            _restclient = restclient;
            _configurationService = configurationService;
        }

        public async Task ProcessPayment(string paymentRequest)
        {
            var paymentObj = JsonConvert.DeserializeObject<Payment>(paymentRequest);
            PaymentRequestCko paymentRequestCko = new()
            {
                amount = paymentObj.amount,
                currency = paymentObj.currency,
                source = new()
                {
                    country = paymentObj.country,
                    integration_type = "redirect",
                    type = "oxxo",
                    description = "simulate OXXO Demo Payment",
                    payer = new()
                    {
                        name = paymentObj.name,
                        email = paymentObj.email
                    }
                }
            };

            var response = await _restclient.PostAsync(_configurationService.GetBankingApiConfig, paymentRequestCko);
        }
    }
}
