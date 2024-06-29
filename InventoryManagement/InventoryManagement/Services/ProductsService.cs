using InventoryManagement.Contracts;
using InventoryManagement.Models;
using System;

namespace InventoryManagement.Services
{
    public class ProductsService : IProducts
    {
        private readonly InventoryDBContext _dbContext;
        public ProductsService(InventoryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product Add(Product entity)
        {
            try
            {
                _dbContext.Products.Add(entity);
                _dbContext.SaveChanges();
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

        public IEnumerable<Product> GetAll()
        {
            var result = _dbContext.Products.OrderBy(p => p.ProductName).ToList();
            return result;
        }

        public Product GetById(int id)
        {
            Product result = _dbContext.Products.Where(p => p.ProductId == id).FirstOrDefault();
            if (result == null)
            {
                throw new Exception("Product not found");
            }
            return result;
        }

        public IEnumerable<Product> GetProductByName(string productName)
        {
            var results = _dbContext.Products.Where(p => p.ProductName.Contains(productName)).ToList();
            return results;
        }

        public Product Update(Product entity)
        {
            try
            {
                var updateProduct = GetById(entity.ProductId);
                if (updateProduct != null)
                {
                    updateProduct.ProductName = entity.ProductName;
                    updateProduct.StockLevel = entity.StockLevel;
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Product Not Found");
                }
                return updateProduct;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
