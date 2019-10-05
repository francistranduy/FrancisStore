﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Service.Products.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
    }
}
