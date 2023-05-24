using BusinessObject.Objects;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetList();
        Order GetOrder(int id);
        void InsertOrder(Order prod);
        void UpdateOrder(Order prod);
        void DeleteOrder(int id);
    }
}