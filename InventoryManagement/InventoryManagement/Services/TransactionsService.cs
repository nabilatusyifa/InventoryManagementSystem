using InventoryManagement.Contracts;
using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Services
{
    public class TransactionsService : ITransactions
    {
        private readonly InventoryDBContext _dbContext;
        public TransactionsService(InventoryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Transaction Add(Transaction entity)
        {
            try
            {
                _dbContext.Transactions.Add(entity);
                _dbContext.SaveChanges();
                _dbContext.Entry(entity).Reload();
                return entity;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetAll()
        {
            var result = _dbContext.Transactions.ToList();
            return result;
        }

        public Transaction GetById(int id)
        {
            Transaction result = _dbContext.Transactions.Where(t => t.TransactionId == id).FirstOrDefault();
            if (result == null)
            {
                throw new Exception("Transaction not found");
            }
            return result;
        }

        public IEnumerable<Transaction> GetTransactionByProduct()
        {
            var results = _dbContext.Transactions.Include(t => t.Product).ToList();
            return results;
        }

        public Transaction Update(Transaction entity)
        {
            throw new NotImplementedException();
        }
    }
}
