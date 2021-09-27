using BestDeal.Core.Models;
using BestDeal.Proxy.Common;
using BestDeal.Proxy.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestDeal.Proxy.Network.External
{
    public class CompanyOneProxy : IPartnerProxy
    {
        private readonly IHttpHelper _httpHelper;
        private readonly string _urlBase;
        public string Name { get; private set; }              

        public CompanyOneProxy(IHttpHelper httpHelper, IConfiguration config)
        {
            _httpHelper = httpHelper;
            Name = config["PartnerApis:PartnerOne:Name"].ToString();
            _urlBase = config["PartnerApis:PartnerOne:Url"].ToString();
        }

        public async Task<SearchResponse> ExecuteQuery(SearchParams parameters)
        {
            try
            { 
                var Url = new Uri($"{_urlBase}/{parameters.SourceAddress}/{parameters.DestinationAddress}");
                const string key = "dimensions";
                var queryParams = parameters.CartonDimensions.Select(d => new KeyValuePair<string, string>(key, d.ToString()));

                var response = await _httpHelper.GetAsync<CompanyOneResponse>(Url, queryParams);
                if (response != null)
                    return new SearchResponse() { Name = this.Name, Total = response.Total };
                else
                    return null;                               

            }
            catch (Exception ex)
            {
                //todo:log API exception
                //Returns null so it doesn't affect other queries
                return null;
            }
}
    }
}
