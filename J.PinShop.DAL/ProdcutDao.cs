using J.PinShop.Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J.PinShop.DAL
{
   public class ProdcutDao
    {
        ISession session = NHibernateSessionFactory.GetSession();
        public IList<Product> GetAll()
        {
            return session.CreateCriteria< Product>().List<Product>();
        }

        public Product Get(int id)
        {
            return session.Get<Product>(id);
        }

        public int Insert(Product p)
        {
            var i= session.Save(p);
            session.Flush();

            return Convert.ToInt32(i);
        }

        public void Delete(int id)
        {
            var entity = Get(id);
            if (entity!=null)
            {
                session.Delete(entity);
                session.Flush();

            }

        }

        public bool Update(Product p)
        {
            session.SaveOrUpdate(p);
            session.Flush();
            return true;
        }

        public IList<Product> FindPaged(int pageIndex,int pageSize,out int totalRecords)
        {
            totalRecords= session.QueryOver<Product>().RowCount();

            var result= session.QueryOver<Product>().OrderBy(r=>r.ProductId).Desc.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return result.List();
        }
        
    }
}
