using BankApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApi.Services
{
    public interface IJsonObjectConverter
    {
        IndividualPayment ConvertPaymentJsonDataToObj(string jsonData);
    }
}
