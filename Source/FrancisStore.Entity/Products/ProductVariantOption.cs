using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Entity.Products
{
    public class ProductVariantOption
    {
        [Key]
        public long ProductVariantId { get; set; }
        [Key]
        public long ProductPropertyId { get; set; }
        [DataType(DataType.Text), StringLength(255)]
        public string Value { get; set; }

        public virtual ProductProperty Property { get; set; }
    }
}
