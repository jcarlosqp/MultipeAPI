using BestDeal.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestDeal.Services.Common
{
    public class LocalMemoryCache<T>
    {
        const long _MEMORY_SIZE_LIMIT = 1024;
        const long _MEMORY_TIME_EXPIRATION = 300;
        private readonly IMemoryCache _cache;

        public LocalMemoryCache(IMemoryCache cache)
        {
            _cache = cache;
        }
        
        public static string GenerateKey(SearchParams parameters)
        {
            return $"{parameters.SourceAddress},{parameters.DestinationAddress}," + 
                    string.Join(",", parameters.CartonDimensions);
        }

        public async static Task<T> GetOrCreateAsync(IMemoryCache cache, object key, Func<Task<T>> executeLogic)
        {
            T cacheEntry;
            cacheEntry = await cache.GetOrCreateAsync(key, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(_MEMORY_TIME_EXPIRATION);
                return executeLogic();
            });

            return cacheEntry;
        }


    }
}
