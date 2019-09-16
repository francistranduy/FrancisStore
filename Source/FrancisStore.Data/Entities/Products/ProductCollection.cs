using FrancisStore.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Data.Entities.Products
{
    public class ProductCollection: BaseEntity
    {
        [Required, DataType(DataType.Text), StringLength(255)]
        public string Name { get; set; }
        public long? ImageId { get; set; }
        public virtual Image Image { get; set; }
        public virtual ICollection<Collect> Collects { get; set; }
    }
}
