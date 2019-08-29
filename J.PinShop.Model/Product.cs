using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J.PinShop.Model
{
  public  class Product
    {
        public virtual int ProductId { get; set; }
        public virtual string ProductName { get; set; }
        public virtual string EanCode { get; set; }
        public virtual string ShortName { get; set; }

        public virtual decimal B2CGuidPrice { get; set; }
        public virtual Guid OwnerFroleId { get; set; }
    }
}
