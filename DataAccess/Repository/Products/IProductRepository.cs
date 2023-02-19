using System;
using System.Collections.Generic;
using BusinessObject.Objects;

namespace DataAccess.Repository.Products
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