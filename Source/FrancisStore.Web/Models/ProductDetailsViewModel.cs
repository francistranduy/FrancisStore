using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrancisStore.Web.Models
{
    public class ProductDetailsViewModel
    {
        [Required, Range(1, Int64.MaxValue)]
        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Note { get; set; }
        public string Tags { get; set; }
        public string Description { get; set; }
        public string AdditionalInformation { get; set; }

        public IList<string> Images { get; set; }
        public IList<string> Properties { get; set; }
        public IDictionary<string, IList<string>> Options { get; set; }
        public IList<ProductViewModel> RelatedProduct { get; set; }
    }
}