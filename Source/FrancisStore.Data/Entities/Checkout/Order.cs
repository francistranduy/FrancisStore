using FrancisStore.Data.Entities.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Data.Entities.Checkout
{
    public class Order :BaseEntity
    {
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public DateTime Date { get; set; }

        [StringLength(160)]
        public string FirstName { get; set; }

        [StringLength(160)]
        public string LastName { get; set; }

        [StringLength(70)]
        public string Address { get; set; }

        [StringLength(40)]
        public string City { get; set; }

        [StringLength(40)]
        public string State { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }


        [StringLength(24)]
        public string Phone { get; set; }

        public double Total { get; set; }

        public long CountryId { get; set; }

        public string UserId { get; set; }

        public virtual Country Country { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }

        [ForeignKey("UserId")]
        public virtual Identity.FrancisStoreUser User { get; set; }
    }
}
