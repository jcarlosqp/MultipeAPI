using BestDeal.Proxy.Common;
using BestDeal.Proxy.Network.External;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace BestDeal.Proxy.Factories
{

    public class PartnerFactory
    {
        public static IEnumerable<IPartnerProxy> CreateAllPartnerProxies(IHttpHelper httpHelper, IConfiguration config)
        {
            return new List<IPartnerProxy>
            {
                new CompanyOneProxy(httpHelper, config),
                new CompanyTwoProxy(httpHelper, config),
                new XmlCompanyProxy(httpHelper, config)
            };
        }

        //public static IPartnerProxy CreatePartnerProxy(SearcherEnum type, IConfiguration config)
        //{
        //    IPartnerProxy proxy = null;

        //    return proxy;
        //}
    }
}
