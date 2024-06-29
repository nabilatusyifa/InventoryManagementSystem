using InventoryManagement.Models;

namespace InventoryManagement.Contracts
{
    public interface ITransactions : ICrud<Transaction>
    {
        IEnumerable<Transaction> GetTransactionByProduct();
    }
}
