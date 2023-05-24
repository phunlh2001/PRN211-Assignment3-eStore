using System;
using System.Collections.Generic;
using BusinessObject.Objects;
using DataAccess.DaoAccess;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public IEnumerable<OrderDetail> GetList() => OrderDetailDAO.GetInstance.GetAll();
    }
}