using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApi.Models
{
    public class PaymentResponse
    {
        public string SuccessStatus { get; set; }
        public string StatusReason { get; set; }

    }
}
