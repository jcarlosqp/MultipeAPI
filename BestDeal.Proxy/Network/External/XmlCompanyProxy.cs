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
    public class XmlCompanyProxy : IPartnerProxy
    {
        private readonly IHttpHelper _httpHelper;
        private readonly string _urlBase;
        public string Name { get; private set; }              

        public XmlCompanyProxy(IHttpHelper httpHelper, IConfiguration config)
        {
            _httpHelper = httpHelper;
            Name = config["PartnerApis:XmlPartner:Name"].ToString();
            _urlBase = config["PartnerApis:XmlPartner:Url"].ToString();
        }

        public async Task<SearchResponse> ExecuteQuery(SearchParams parameters)
        {
            try
            {
                var Url = new Uri(_urlBase);
                const string key = "Packages";
                var queryParams = new List<KeyValuePair<string, string>>() { 
                    new KeyValuePair<string, string>("Source", parameters.SourceAddress),
                    new KeyValuePair<string, string>("Destination", parameters.DestinationAddress)
                };
                var cartons = parameters.CartonDimensions.Select(d => new KeyValuePair<string, string>(key, d.ToString()));
                queryParams.AddRange(cartons);

                var response = await _httpHelper.GetAsync<ResponseModel>(Url, queryParams);
                
                if (response != null)
                    return new SearchResponse() { Name = this.Name, Total = response.Quota };
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
