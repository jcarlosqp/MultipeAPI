using BestDeal.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BestDeal.Proxy.Network
{
    public interface IFreightProxy
    {
        Task<IEnumerable<SearchResponse>> Search(SearchParams parameters);
    }
}