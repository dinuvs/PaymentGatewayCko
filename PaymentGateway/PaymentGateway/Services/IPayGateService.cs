using PaymentGateway.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Services
{
    public interface IPayGateService
    {
        Task<TransactionDetail> GetTransactionWithIdAsync(int id);
        Task<TransactionDetail> ProcessPaymentAsync(string paymentRequest);
    }
}
