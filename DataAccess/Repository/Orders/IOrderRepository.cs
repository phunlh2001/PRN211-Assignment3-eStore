using System;
using System.Collections.Generic;
using BusinessObject.Objects;

namespace DataAccess.Repository.Orders
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