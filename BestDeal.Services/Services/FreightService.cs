using BestDeal.Core.Models;
using BestDeal.Proxy.Network;
using BestDeal.Services.Common;
using BestDeal.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestDeal.Services.Services
{
    public class FreightService : IFreightService
    {
        private readonly IFreightProxy _proxy;
        private readonly IMemoryCache _cache;

        public FreightService(IFreightProxy proxy, IMemoryCache cache)
        {
            _proxy = proxy;
            _cache = cache;
        }
        public async Task<SearchResponse> SearchBestDeal(SearchParams parameters)
        {
            IEnumerable<SearchResponse> responses = await _proxy.Search(parameters);
            //returning the lowest offer
            SearchResponse bestDeal = responses?.Where(r => r!=null).OrderBy(r => r.Total).FirstOrDefault();
            return bestDeal;
        }

        public async Task<SearchResponse> RunSearch(SearchParams parameters)
        {
            var key = LocalMemoryCache<SearchResponse>.GenerateKey(parameters);
            //Get from Local cache or execute the search.
            SearchResponse searchResult = await LocalMemoryCache<SearchResponse>
                            .GetOrCreateAsync(_cache, key, async () => await SearchBestDeal(parameters));

            return searchResult;
        }
    }
}
