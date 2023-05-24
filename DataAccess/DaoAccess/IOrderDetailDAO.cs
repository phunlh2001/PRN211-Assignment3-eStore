using BusinessObject.Objects;
using System.Collections.Generic;

namespace DataAccess.DaoAccess
{
    public interface IOrderDetailDAO
    {
        IEnumerable<OrderDetail> GetAll();
    }
}