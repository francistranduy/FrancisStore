
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrancisStore.Data.Entities.Bases;

namespace FrancisStore.Data.Entities.Products
{
    public class Product : BaseEntity
    {
        [Required, DataType(DataType.Text), StringLength(255)]
        public string Name { get; set; }
        [DataType(DataType.Text), StringLength(1023)]
        public string Note { get; set; }
        [DataType(DataType.Text), StringLength(255)]
        public string Tags { get; set; }
        [DataType(DataType.MultilineText), StringLength(5000)]
        public string Description { get; set; }
        [DataType(DataType.MultilineText), StringLength(5000)]
        public string AdditionalInformation { get; set; }

        public virtual ICollection<Collect> Collects { get; set; }
        public virtual ICollection<ProductImage> Images { get; set; }
        public virtual ICollection<Variant> Variants { get; set; }
    }
}
