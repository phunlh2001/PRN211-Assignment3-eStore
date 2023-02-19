using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObject.Objects;
using DataAccess.DaoAccess.BaseDAO;
using DataAccess.DaoAccess.Utils;

namespace DataAccess.DaoAccess
{
    public class OrderDAO : IOrderDAO
    {
        //use Singleton
        private static OrderDAO instance;
        private static readonly object instanceLock = new object();
        public static OrderDAO GetInstance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Order> GetAll()
        {
            var order = new List<Order>();
            try
            {
                using var context = new eStoreContext();
                order = context.Orders.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return order;
        }

        public Order GetOne(int id)
        {
            Order order = null;
            try
            {
                using var context = new eStoreContext();
                order = context.Orders.FirstOrDefault(o => o.OrderId == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return order;
        }

        public void Insert(Order order)
        {
            try
            {
                Order _order = GetOne(order.OrderId);
                if (_order == null)
                {
                    order.OrderDate = BaseDate.GetDateNow(); //utils
                    order.RequiredDate = BaseDate.GetCoupleNextDays(); //utils
                    order.ShippedDate = BaseDate.GetSevenNextDays(); //utils
                    order.Freight = 15_000;
                    using var context = new eStoreContext();
                    context.Orders.Add(order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Order is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(Order order)
        {
            try
            {
                Order _order = GetOne(order.OrderId);
                if (_order != null)
                {
                    using var context = new eStoreContext();
                    context.Orders.Update(order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Order does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                Order _order = GetOne(id);
                if (_order != null)
                {
                    using var context = new eStoreContext();
                    context.Orders.Remove(_order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Order is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}