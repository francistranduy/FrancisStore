using FrancisStore.Service.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Service.Products.Interfaces
{
    public interface ICollectionService
    {
        Task<IList<Collection>> GetCollectionsAsync(string searchString = null, int page = 1, int pageSize = 3);
    }
}
