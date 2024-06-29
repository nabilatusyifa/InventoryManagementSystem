using InventoryManagement.Models;

namespace InventoryManagement.Contracts
{
    public interface IProducts : ICrud<Product>
    {
        IEnumerable<Product> GetProductByName(string productName);
    }
}
