﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Entity.Products
{
    public class ProductCollectionImage
    {
        public long ProductCollectionImageId { get; set; }
        [Required, DataType(DataType.ImageUrl), StringLength(255)]
        public string Source { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        [DataType(DataType.Text), StringLength(255)]
        public string AlternativeText { get; set; }
    }
}
