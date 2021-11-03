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
            var test = await _restclient.GetAsync(_configurationService.GetBankingApiGetConfig);

            var paymentObj = JsonConvert.DeserializeObject<Payment>(paymentRequest);
            PaymentRequestBank paymentRequestBank = new()
            {
                amount = paymentObj.amount,
                currency = paymentObj.currency,
                name=paymentObj.name,
                cardnumber=paymentObj.cardnumber,
                expiry=paymentObj.expiry,
                cvv=paymentObj.cvv,
                country=paymentObj.country
               
            };

            var response = await _restclient.PostAsync(_configurationService.GetBankingApiConfig, paymentRequestBank);
        }
    }
}
