﻿using FrancisStore.Data.Entities.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Data.Entities.Products
{
    public class Collection: BaseEntity
    {
        [Required, DataType(DataType.Text), StringLength(255)]
        public string Name { get; set; }
        public virtual ICollection<Collect> Collects { get; set; }
    }
}
