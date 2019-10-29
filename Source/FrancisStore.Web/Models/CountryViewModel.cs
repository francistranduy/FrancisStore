using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrancisStore.Web.Models
{
    public class CountryViewModel
    {
        public long Id { get; set; }
        [StringLength(255), Display(Name = "Country")]
        public string Name { get; set; }
        [StringLength(255), Display(Name = "Shipping Fee")]
        public double ShippingFee { get; set; }
        public bool IsSelected { get; set; }
    }
}