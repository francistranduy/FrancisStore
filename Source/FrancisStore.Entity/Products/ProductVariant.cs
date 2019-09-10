using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Entity.Products
{
    public class ProductVariant
    {
        [DataType(DataType.Text), StringLength(255)]
        public string Title { get; set; }
        [DataType(DataType.Text), StringLength(15)]
        public string SKU { get; set; }
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        public int Position { get; set; }
        public long ImageId { get; set; }

        public long ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<ProductVariantOption> Options { get; set; }
    }
}
