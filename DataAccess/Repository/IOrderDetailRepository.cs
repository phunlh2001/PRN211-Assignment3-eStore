using BusinessObject.Objects;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetList();
    }
}