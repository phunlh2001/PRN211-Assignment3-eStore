using BusinessObject.Objects;
using System.Collections.Generic;

namespace DataAccess.DaoAccess
{
    public interface IOrderDAO
    {
        IEnumerable<Order> GetAll();
        Order GetOne(int id);
        void Insert(Order o);
        void Update(Order o);
        void Delete(int id);
    }
}