using BestDeal.Core.Models;
using BestDeal.Proxy.Network;
using BestDeal.Services.Services;
using BestDeal.Tests.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BestDeal.Tests
{
    public class FreightServiceTest
    {        
        private readonly SearchResponse _searchResponse1;
        private readonly SearchResponse _searchResponse2;
        private readonly SearchResponse _searchResponse3;
        private Mock<FreightProxy> _mockFreightProxy;
        public FreightServiceTest()
        {            
            _searchResponse1 = new SearchResponse() { Name = "Partner1", Total = 10 };
            _searchResponse2 = new SearchResponse() { Name = "Partner2", Total = 20 };
            _searchResponse3 = new SearchResponse() { Name = "Partner3", Total = 30};
        }
        [Fact]
        public async Task SearchBestDealOfTwoResponsesTest()
        {
            //Arrange
            _mockFreightProxy = FreightProxyMock.GetMock( new List<SearchResponse>() { _searchResponse2, _searchResponse3 });
            var service = new FreightService(_mockFreightProxy.Object, null);
            double bestDealExpected = 20;

            //Act
            var result = await service.SearchBestDeal(new SearchParams());

            //Assert
            Assert.Equal(bestDealExpected, result.Total);
        }

        [Fact]
        public async Task SearchBestDealOfThreeResponsesTest()
        {
            //Arrange
            _mockFreightProxy = FreightProxyMock.GetMock(new List<SearchResponse>() { _searchResponse1, _searchResponse2, _searchResponse3 });
            var service = new FreightService(_mockFreightProxy.Object, null);
            double bestDealExpected = 10;
            
            //Act
            var result = await service.SearchBestDeal(new SearchParams());

            //Assert
            Assert.Equal(bestDealExpected, result.Total);
        }

        [Fact]
        public async Task SearchBestDealWhenSomeApisNotWorkingAndReturnNullTest()
        {
            //Arrange
            _mockFreightProxy = FreightProxyMock.GetMock(new List<SearchResponse>() { null, _searchResponse3, null });
            var service = new FreightService(_mockFreightProxy.Object, null);
            double bestDealExpected = 30;
            string partnerExpected = "Partner3";

            //Act
            var result = await service.SearchBestDeal(new SearchParams());

            //Assert
            Assert.Equal(partnerExpected, result.Name);
            Assert.Equal(bestDealExpected, result.Total);
        }
    }
}
