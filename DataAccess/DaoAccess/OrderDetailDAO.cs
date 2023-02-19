using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObject.Objects;
using DataAccess.DaoAccess.BaseDAO;

namespace DataAccess.DaoAccess
{
    public class OrderDetailDAO : IOrderDetailDAO
    {
        //use singleton
        private static OrderDetailDAO instance;
        private static readonly object instanceLock = new object();
        public static OrderDetailDAO GetInstance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            var orderDetails = new List<OrderDetail>();
            try
            {
                using var context = new eStoreContext();
                orderDetails = context.OrderDetails.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orderDetails;
        }
    }
}