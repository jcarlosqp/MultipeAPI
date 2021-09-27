using BestDeal.Core.Models;
using BestDeal.Proxy.Common;
using BestDeal.Proxy.Factories;
using BestDeal.Proxy.Network.External;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestDeal.Proxy.Network
{
    public class FreightProxy : IFreightProxy
    {
        private readonly IEnumerable<IPartnerProxy> _proxies;
        public FreightProxy()
        {
            _proxies = null;
        }
        public FreightProxy(IHttpHelper helper, IConfiguration config)
        {
            _proxies = PartnerFactory.CreateAllPartnerProxies(helper, config);
        }
        public async virtual Task<IEnumerable<SearchResponse>> Search(SearchParams parameters)
        {
            //Optimization for Parallel Searchs
            var searchTasks = new List<Task<SearchResponse>>();

            foreach (var proxy in _proxies)
            {
                searchTasks.Add(Task.Run(async () => await proxy.ExecuteQuery(parameters)));
            }
            await Task.WhenAll(searchTasks);

            return searchTasks.Select(s => s.Result);
        }

    }
}
