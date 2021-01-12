using System.Collections.Generic;
using System.Threading.Tasks;
using Dummy.ViewModel;

namespace Dummy.Repositories
{
    public interface ISalesRepository
    {
        Task<IEnumerable<OrdersTotalByYearViewModel>> GetOrdersTotalByYear();
        Task<List<TopSellerViewModel>> GetTopSeller(int top);
    }
}