using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Data.Entities.Products
{
    public class ProductVariantOption
    {
        [Key, Column(Order = 1)]
        public long ProductVariantId { get; set; }
        [Key, Column(Order = 2)]
        public long ProductPropertyId { get; set; }
        [DataType(DataType.Text), StringLength(255)]
        public string Value { get; set; }

        public virtual ProductProperty Property { get; set; }
    }
}
