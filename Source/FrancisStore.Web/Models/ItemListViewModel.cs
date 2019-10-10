using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrancisStore.Web.Models
{
    public class ItemListViewModel
    {
        public IEnumerable<ItemViewModel> Items { get; set; }
        public double Subtatol { get; set; }
    }
}