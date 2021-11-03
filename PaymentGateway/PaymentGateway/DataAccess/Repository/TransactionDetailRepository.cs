using PaymentGateway.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.DataAccess.Repository
{
    public class TransactionDetailRepository : ITransactionDetailRepository
    {
        private readonly AppDbContext _context;
        public TransactionDetailRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TransactionDetail> AddAsync(TransactionDetail transaction)
        {
            _context.TransactionDetail.Add(transaction);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return transaction;
            }
            return null;
        }

        public async Task<TransactionDetail> GetTransactionAsync(int id)
        {
            return await _context.TransactionDetail.FindAsync(id);
        }

    }
}
