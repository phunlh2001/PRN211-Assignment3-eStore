using System;
using System.Collections.Generic;
using BusinessObject.Objects;

namespace DataAccess.DaoAccess.BaseDAO
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