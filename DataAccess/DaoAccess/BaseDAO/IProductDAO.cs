using System;
using System.Collections.Generic;
using BusinessObject.Objects;

namespace DataAccess.DaoAccess.BaseDAO
{
    public interface IProductDAO
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Insert(Product prod);
        void Update(Product prod);
        void Delete(int id);
        IEnumerable<Product> GetByName(string name);
    }
}