using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Models
{

    public class PaymentRequestBank
    {
        public string name { get; set; }
        public string country { get; set; }
        public int amount { get; set; }
        public string currency { get; set; }
        public string cardnumber { get; set; }
        public string expiry { get; set; }
        public string cvv { get; set; }
    }
 }