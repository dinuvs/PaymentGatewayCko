using PaymentGateway.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.DataAccess.Repository
{
    public interface ITransactionDetailRepository
    {
        Task<TransactionDetail> AddAsync(TransactionDetail transaction);
        Task<TransactionDetail> GetTransactionAsync(int id);
    }
}
