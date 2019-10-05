using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Service.Products.Models
{
    public class ProductDetails
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Note { get; set; }
        public string Tags { get; set; }
        public string Description { get; set; }
        public string AdditionalInformation { get; set; }

        public IList<string> Images { get; set; }
        public IDictionary<string, IList<string>> Options { get; set; }
        public IList<Product> RelatedProduct { get; set; }

    }
}
