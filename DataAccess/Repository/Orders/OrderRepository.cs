using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObject.Objects;
using DataAccess.DaoAccess;

namespace DataAccess.Repository.Orders
{
    public class OrderRepository : IOrderRepository
    {
        public IEnumerable<Order> GetList() => OrderDAO.GetInstance.GetAll();
        public Order GetOrder(int id) => OrderDAO.GetInstance.GetOne(id);
        public void InsertOrder(Order order) => OrderDAO.GetInstance.Insert(order);
        public void UpdateOrder(Order order) => OrderDAO.GetInstance.Update(order);
        public void DeleteOrder(int id) => OrderDAO.GetInstance.Delete(id);
    }
}