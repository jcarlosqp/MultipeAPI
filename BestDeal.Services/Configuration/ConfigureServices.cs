using BestDeal.Proxy.Common;
using BestDeal.Proxy.Network;
using BestDeal.Services.Interfaces;
using BestDeal.Services.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace BestDeal.Services.Configuration
{

    public class ConfigureServices
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddHttpClient("BestDeal").ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler { UseDefaultCredentials = true });
            services.AddSingleton<IFreightService, FreightService>();
            services.AddSingleton<IFreightProxy, FreightProxy>();
            services.AddSingleton<IHttpHelper, HttpHelper>();

            services.AddMemoryCache(m => new MemoryCacheOptions()
            {
                SizeLimit = 1024
            });
        }
    }
}
