using BestDeal.Core.Models;
using System.Threading.Tasks;

namespace BestDeal.Services.Interfaces
{
    public interface IFreightService
    {
        Task<SearchResponse> SearchBestDeal(SearchParams parameters);
        Task<SearchResponse> RunSearch(SearchParams parameters);
    }
}