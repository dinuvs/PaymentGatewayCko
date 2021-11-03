using BankApi.Models;
using Newtonsoft.Json;

namespace BankApi.Services
{
    public class JsonObjectConverter : IJsonObjectConverter
    {
        public IndividualPayment ConvertPaymentJsonDataToObj(string jsonData)
        {
            return JsonConvert.DeserializeObject<IndividualPayment>(jsonData);
        }
    }
}
