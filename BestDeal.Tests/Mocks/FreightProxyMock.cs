using BestDeal.Core.Models;
using BestDeal.Proxy.Network;
using Moq;
using System.Collections.Generic;

namespace BestDeal.Tests.Mocks
{
    public class FreightProxyMock
    {
        public static Mock<FreightProxy> GetMock(IEnumerable<SearchResponse> responses)
        {
            var searchResponses = new List<SearchResponse>() {
                new SearchResponse(){ Name="Partner1", Total=10},
                new SearchResponse(){ Name="Partner2", Total=20}
            };

            var mockObj = new Mock<FreightProxy>();
            mockObj.Setup(proxy => proxy.Search(It.IsAny<SearchParams>())).ReturnsAsync(responses);
            return mockObj;
        }
    }
}
