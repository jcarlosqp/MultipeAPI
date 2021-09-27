using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BestDeal.Proxy.Common
{
    public interface IHttpHelper
    {
        Task<TResult> GetAsync<TResult>(Uri url, IEnumerable<KeyValuePair<string, string>> parameters);
    }
}