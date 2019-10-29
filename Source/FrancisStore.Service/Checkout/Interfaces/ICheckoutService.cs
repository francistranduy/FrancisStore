using FrancisStore.Service.Checkout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Service.Checkout.Interfaces
{
    public interface ICheckoutService
    {
        Task<long> AddOrder(Order order);
    }
}
