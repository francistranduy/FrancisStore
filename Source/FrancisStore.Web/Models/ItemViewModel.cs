using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrancisStore.Web.Models
{
    public class ItemViewModel
    {
        public long Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Options { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public double Total { get; set; }
    }
}