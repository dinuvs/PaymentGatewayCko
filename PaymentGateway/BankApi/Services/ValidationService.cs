using BankApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApi.Services
{
    public class ValidationService : IValidationService
    {
        public string ValidationMessage { get; set; }

        public (bool, string) ValidateCardDetails(IndividualPayment payment)
        {
            if(ValidateCardNumber(payment) && ValidateCardExpiry(payment) && ValidateCvv(payment))
            {
                return (true, "Validation Successful");
            }
            return (false, ValidationMessage);
           
        }

        private bool ValidateCardNumber(IndividualPayment payment)
        {
            if (!int.TryParse(payment.cardnumber.Trim(), out _))
            {
                ValidationMessage= "Invalid Card Number ";
                return false;
            }
            return true;
        }

        private bool ValidateCardExpiry(IndividualPayment payment)
        {
            
            if (!payment.expiry.Contains("/") || 
                !int.TryParse(payment.expiry.Split("/")[0].Trim(), out _) || 
                !int.TryParse(payment.expiry.Split("/")[1].Trim(), out _) || 
                int.Parse(payment.expiry.Split("/")[0].Trim()) > 12)
            {
                ValidationMessage += "Invalid expiry details ";
                return false;
            }

           
            if (int.Parse(payment.expiry.Split("/")[0].Trim()) < DateTime.Now.Month
                || int.Parse(payment.expiry.Split("/")[1].Trim()) < DateTime.Now.Year)
            {
                ValidationMessage += "Card is expired ";
            }
            return true;
        }


        private bool ValidateCvv(IndividualPayment payment)
        {
            if (!int.TryParse(payment.cvv.Trim(), out _) && payment.cvv.Trim().Length != 3)
            {
                ValidationMessage = "Invalid cvv ";
                return false;
            }
            return true;
        }
    }
}
