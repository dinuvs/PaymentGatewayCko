using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Services
{
    public interface IPayGateService
    {
        Task ProcessPayment(string paymentRequest);
    }
}
