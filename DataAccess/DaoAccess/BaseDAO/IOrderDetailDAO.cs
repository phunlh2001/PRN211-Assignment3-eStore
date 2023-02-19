using System;
using System.Collections.Generic;
using BusinessObject.Objects;

namespace DataAccess.DaoAccess.BaseDAO
{
    public interface IOrderDetailDAO
    {
        IEnumerable<OrderDetail> GetAll();
    }
}