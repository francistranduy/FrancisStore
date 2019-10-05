using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrancisStore.Web.Models
{
    public class PagedListViewModel
    {
        public string Search { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public int Total { get; set; }
    }
}