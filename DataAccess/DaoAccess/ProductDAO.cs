using BusinessObject.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.DaoAccess
{
    public class ProductDAO : IProductDAO
    {
        //use Singleton
        private static ProductDAO instance;
        private static readonly object instanceLock = new object();
        public static ProductDAO GetInstance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Product> GetAll()
        {
            var prod = new List<Product>();
            try
            {
                using var context = new eStoreContext();
                prod = context.Products.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return prod;
        }

        public Product GetById(int id)
        {
            Product prod = null;
            try
            {
                using var context = new eStoreContext();
                prod = context.Products.FirstOrDefault(p => p.ProductId == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return prod;
        }

        public void Insert(Product prod)
        {
            try
            {
                Product _prod = GetById(prod.ProductId);
                if (_prod == null)
                {
                    using var context = new eStoreContext();
                    context.Products.Add(prod);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Product is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(Product prod)
        {
            try
            {
                Product _prod = GetById(prod.ProductId);
                if (_prod != null)
                {
                    using var context = new eStoreContext();
                    context.Products.Update(prod);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Product does not already exist.");
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
                Product _prod = GetById(id);
                if (_prod != null)
                {
                    using var context = new eStoreContext();
                    context.Products.Remove(_prod);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Product is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<Product> GetByName(string name)
        {
            IEnumerable<Product> prods = null;
            try
            {
                if (name != null)
                {
                    using var context = new eStoreContext();
                    prods = context.Products.Where(p => p.ProductName == name);
                }
                else
                {
                    throw new Exception("Search Input not null");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return prods;
        }
    }
}