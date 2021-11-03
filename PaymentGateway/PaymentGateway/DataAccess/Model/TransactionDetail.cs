using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.DataAccess.Model
{
    public class TransactionDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        
        public string CardNumber { get; set; }
        public string Expiry { get; set; }
        public string Cvv { get; set; }
        public string Status { get; set; }
        public string StatusReason { get; set; }
        public DateTime LastUpdated { get; set; }

    }
}
