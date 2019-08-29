using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace J.PinShop.DAL
{
   public class NHibernateSessionFactory
    {
        public static ISessionFactory _ISessionFactory { get {
                return (new Configuration()).Configure()
                    .AddAssembly("J.PinShop.Model")
                    .BuildSessionFactory();
            }}

        public static ISession GetSession()
        {
            return _ISessionFactory.OpenSession();
        }
    }
}
