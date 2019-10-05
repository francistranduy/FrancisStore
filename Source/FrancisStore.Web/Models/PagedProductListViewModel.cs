using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrancisStore.Web.Models
{
    public class PagedProductListViewModel
    {
        public PagedListViewModel PagedList { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
        public IEnumerable<CollectionViewModel> Collections { get; set; }
    }
}