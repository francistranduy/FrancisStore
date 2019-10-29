using FrancisStore.Data.Entities.Bases;
using FrancisStore.Data.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Data.Entities.Checkout
{
    public class OrderDetail : BaseEntity
    {
        public long OrderId { get; set; }
        public long VariantId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public virtual Variant Variant { get; set; }
        public virtual Order Order { get; set; }
    }
}
