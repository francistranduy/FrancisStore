using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrancisStore.Web.Models
{
    public class CollectionViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}