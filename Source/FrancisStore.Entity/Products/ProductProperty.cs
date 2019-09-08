﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Entity.Products
{
    public class ProductProperty
    {
        public int ProductPropertyId { get; set; }
        [Required, DataType(DataType.Text), StringLength(255)]
        public string Name { get; set; }
    }
}
