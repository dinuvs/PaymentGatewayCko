using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Models
{
    public class PaymentBankResponse
    {
        public string SuccessStatus { get; set; }
        public string StatusReason { get; set; }

    }
}
