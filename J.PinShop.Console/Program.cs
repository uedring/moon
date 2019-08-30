using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace J.PinShop.Console
{
    class Program
    {
        static  void Main(string[] args)
        {
            var dao = new DAL.ProdcutDao();
            //var pdts = dao.GetAll();

            //foreach (var item in pdts)
            //{
            //    System.Console.WriteLine($"编号：{item.ProductId}\t 名称{item.ProductName}");
            //}

            //10257399
            //var id = dao.Insert(new Model.Product()
            //{
            //    OwnerFroleId = Guid.Parse("5BEFFCC2-04F0-40A5-8AC1-1F48DF5BA59C"),
            //    ShortName = "a",
            //    ProductName = "我是新建的"
            //});


            //var p = dao.Get(10257402);
            //p.ShortName = "1111111111111111";
            //dao.Update(p);

            //int totalRecords;
            // var pdts=dao.FindPaged(2, 20, out totalRecords);

            //System.Console.WriteLine($"总数是：{totalRecords}");
            //for (int i = 0; i < pdts.Count; i++)
            //{
            //    System.Console.WriteLine($"{i+1}\t{pdts[i].ProductId}\t{pdts[i].ProductName}");
            //}

            GetObjectFromSpring();

            System.Console.ReadKey();
        }

        static void GetObjectFromSpring()
        {
            var ctx= Spring.Context.Support.ContextRegistry.GetContext();
            var prodcut= ctx.GetObject<Model.Product>();

            System.Console.WriteLine(prodcut.OwnerFroleId);
        }

        static void SortString()
        {
            string s="hello world";
           
            var ss= s.OrderBy(r => r).ToArray();
            System.Console.WriteLine(new string(ss));
        }

        public static async Task<int> SumAsync(int count)
        {
            return await Task.Factory.StartNew(()=>
            {
                System.Threading.Thread.Sleep(2 * 1000);
                int sum = 0;
                for (int i = 0; i < count; i++)
                {
                    sum += i;
                }

                return sum;
            });
        }

        public static async Task<int> SumAsync2(int count)
        {
            await Task.Delay(1);
            System.Threading.Thread.Sleep(2 * 1000);
            int sum = 0;
            for (int i = 0; i < count; i++)
            {
                sum += i;
            }

            return sum;
        }
        static void XmlTest()
        {
            string xml = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><root><items><item name=\"TOM\"></item><item name=\"Jerry\"></item><item name=\"Join\"></item></items></root>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

           var nodes= doc.SelectNodes("//item[@name='Jerry']");
            foreach (XmlNode item in nodes)
            {
                System.Console.WriteLine(item.Attributes["name"].Value);
            }
        }
    }
}
