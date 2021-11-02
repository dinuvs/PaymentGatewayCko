using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Models
{
    public class Payer
    {
        public string name { get; set; }
        public string email { get; set; }
    }

    public class Source
    {
        public string type { get; set; }
        public string integration_type { get; set; }
        public string country { get; set; }
        public Payer payer { get; set; }
        public string description { get; set; }
    }

    public class PaymentRequestCko
    {
        public Source source { get; set; }
        public int amount { get; set; }
        public string currency { get; set; }
    }
 }