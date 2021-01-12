using System.Collections.Generic;
using System.Threading.Tasks;
using Dummy.Models;

namespace Dummy.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<IEnumerable<Category>> GetGroupByCategory(int? categoryID);
    }
}