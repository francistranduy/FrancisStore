using FrancisStore.Data.Entities.Bases;
using FrancisStore.Data.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Data.Entities.Shopping
{
    public class Item : BaseEntity
    {
        public Guid ShoppingCartId { get; set; }
        public long VariantId { get; set; }
        public int Count { get; set; }
        public  DateTime? DateCreated { get; set; }
        public virtual Variant Variant { get; set; }
    }
}
