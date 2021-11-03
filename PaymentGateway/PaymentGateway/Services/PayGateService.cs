using Newtonsoft.Json;
using PaymentGateway.DataAccess.Model;
using PaymentGateway.DataAccess.Repository;
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
        private readonly ITransactionDetailRepository _transactionDetailRepository;

        public PayGateService(IRestClient restclient,IConfigurationService configurationService, ITransactionDetailRepository transactionDetailRepository)
        {
            _restclient = restclient;
            _configurationService = configurationService;
            _transactionDetailRepository = transactionDetailRepository;
        }


        public async Task<TransactionDetail> GetTransactionWithIdAsync(int id)
        {
            return await _transactionDetailRepository.GetTransactionAsync(id);
        }

        public async Task<TransactionDetail> ProcessPaymentAsync(string paymentRequest)
        {
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
            string maskedCardNumber = "";
            if (!string.IsNullOrEmpty(paymentObj?.cardnumber))
            {
                var maskSize = paymentObj.cardnumber.Length - 4;
                maskedCardNumber = new string('*', maskSize) + paymentObj.cardnumber.Substring(maskSize);
            }

            TransactionDetail transactionDetail = new()
            {
                Name = paymentObj.name,
                Amount = paymentObj.amount,
                Country = paymentObj.country,
                Email = paymentObj.email,
                Description = paymentObj.description,
                Currency = paymentObj.currency,
                CardNumber = maskedCardNumber,
                Expiry = paymentObj.expiry,
                Cvv = paymentObj.cvv,
                LastUpdated = DateTime.Now
            };

            if (response == "UnSuccessful")
            {
                transactionDetail.Status = "UnSuccessful";
                transactionDetail.StatusReason = "Banking Api issue";
            }
            else
            {
                var result=JsonConvert.DeserializeObject<PaymentBankResponse>(response);
                transactionDetail.Status = result.SuccessStatus;
                transactionDetail.StatusReason = result.StatusReason;
            }

            return await _transactionDetailRepository.AddAsync(transactionDetail);
        }
    }
}
