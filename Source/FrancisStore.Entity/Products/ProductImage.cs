using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Entity.Products
{
    public class ProductImage
    {
        public long ProductId { get; set; }

        [Required, DataType(DataType.ImageUrl), StringLength(255)]
        public string Source { get; set; }
        [DataType(DataType.Text), StringLength(255)]
        public string Alternative { get; set; }
    }
}
