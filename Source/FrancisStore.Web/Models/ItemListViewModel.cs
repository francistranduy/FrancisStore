using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrancisStore.Web.Models
{
    public class ItemListViewModel
    {
        public IEnumerable<ItemViewModel> Items { get; set; }
        public double Subtotal { get; set; }
        public IEnumerable<CountryViewModel> Countries { get; set; }
    }
}