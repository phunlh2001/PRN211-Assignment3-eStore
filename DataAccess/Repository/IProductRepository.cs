using BusinessObject.Objects;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetList();
        Product GetProduct(int id);
        IEnumerable<Product> GetByName(string name);
        void InsertProduct(Product prod);
        void UpdateProduct(Product prod);
        void DeleteProduct(int id);
    }
}