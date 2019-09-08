using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Entity.Products
{
    public class Collect
    {
        [Key, Column(Order = 1)]
        public long ProductId { get; set; }
        [Key, Column(Order = 2)]
        public long ProductCollectionId { get; set; }
        public int Position { get; set; }

        public virtual Product Product { get; set; }
        public virtual ProductCollection Collection { get; set; }
    }
}
