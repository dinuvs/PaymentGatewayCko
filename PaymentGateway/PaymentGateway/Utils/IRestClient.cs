using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Utils
{
    public interface IRestClient
    {
        Task<string> GetAsync(string url);
        Task<string> PostAsync<TIn>(string uri, TIn content);
    }
}
