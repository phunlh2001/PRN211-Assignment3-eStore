using System;
using System.Collections.Generic;
using BusinessObject.Objects;

namespace DataAccess.Repository.OrderDetails
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetList();
    }
}