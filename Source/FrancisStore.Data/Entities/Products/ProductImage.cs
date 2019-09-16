using FrancisStore.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Data.Entities.Products
{
    public class ProductImage : BaseEntity
    {
        public long ProductId { get; set; }

        [Required, DataType(DataType.ImageUrl), StringLength(255)]
        public string Source { get; set; }
        [DataType(DataType.Text), StringLength(255)]
        public string Alternative { get; set; }
    }
}
