using BestDeal.Core.Models;
using System.Threading.Tasks;

namespace BestDeal.Proxy.Network.External
{
    public interface IPartnerProxy
    {
        string Name { get; }

        Task<SearchResponse> ExecuteQuery(SearchParams parameters);
    }
}