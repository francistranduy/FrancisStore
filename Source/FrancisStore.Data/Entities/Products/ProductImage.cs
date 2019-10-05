using FrancisStore.Data.Entities.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Data.Entities.Products
{
    public class ProductImage : BaseEntity 
    {
        public long ProductId { get; set; }
        public long ImageId { get; set; }
        public virtual Image Image { get; set; }
    }
}
