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
    public class Option : BaseEntity
    {
        public long VariantId { get; set; }
        public long PropertyId { get; set; }
        [DataType(DataType.Text), StringLength(255)]
        public string Value { get; set; }

        public virtual Property Property { get; set; }
    }
}
