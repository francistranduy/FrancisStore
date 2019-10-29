using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Service.Shopping.Models
{
    public class Country
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double ShippingFee { get; set; }
    }
}
