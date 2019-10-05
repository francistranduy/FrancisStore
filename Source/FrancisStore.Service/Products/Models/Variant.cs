using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Service.Products.Models
{
    public class Variant
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string SKU { get; set; }
        public double Price { get; set; }
        public int Position { get; set; }
        public IDictionary<string, string> Options { get; set; }
    }
}
