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
    public class Collect : BaseEntity
    {
        public long ProductId { get; set; }
        public long CollectionId { get; set; }
        public int Position { get; set; }
        public virtual Product Product { get; set; }
        public virtual Collection Collection { get; set; }
    }
}
