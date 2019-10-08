using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Service.Shopping.Models
{
    public class Item
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Dictionary<string, string> Properties { get; set; }
        public int Count { get; set; }

        public DateTime? DateCreated { get; set; }
    }
}
