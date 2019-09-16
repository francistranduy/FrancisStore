using FrancisStore.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Data.Entities.Products
{
    public class ProductVariant : BaseEntity
    {
        [DataType(DataType.Text), StringLength(255)]
        public string Title { get; set; }
        [DataType(DataType.Text), StringLength(15)]
        public string SKU { get; set; }
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        public int Position { get; set; }
        public long ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<ProductVariantOption> Options { get; set; }
    }
}
