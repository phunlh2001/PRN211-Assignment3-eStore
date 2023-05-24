using BusinessObject.Objects;
using System.Collections.Generic;

namespace DataAccess.DaoAccess
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