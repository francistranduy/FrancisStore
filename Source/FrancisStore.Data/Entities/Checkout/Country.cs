using FrancisStore.Data.Entities.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Data.Entities.Checkout
{
    public class Country: BaseEntity
    {
        [Required, StringLength(4)]
        public string CountryCode { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Required, Range(0, 500)]
        public double ShippingFee { get; set; }
    }
}
