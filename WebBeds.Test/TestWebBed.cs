namespace WebBeds.Test
{
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WebBeds.Repository;
    using WebBeds.Service;
    using Xunit;

    public class TestWebBed
    {
        private readonly string authCode = "aWH1EX7ladA8C/oWJX5nVLoEa4XKz2a64yaWVvzioNYcEo8Le8caJw==";
        private readonly string apiMethodName = "findBargain";

        /// <summary>
        /// Throws exception when GetHotel is called then exception is thrown
        /// </summary>
        [Fact]
        public async void GivenRepositoryThrowsException_WhenGetHotelsIsCalled_ThenExceptionIsThrown()
        {
            // Given
            var destinationId = 279;
            var nights = 2;
            var repository = new Mock<IWebBedsRepository>();
            repository.Setup(item => item.GetHotels(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Throws<Exception>();
            var hotelService = new HotelService(repository.Object);

            // When
            Func<Task> action = async () => await hotelService.GetHotels(apiMethodName, destinationId, nights, authCode);
            await Assert.ThrowsAnyAsync<Exception>(action);
        }

        /// <summary>
        /// Returns null when GetHotel is called then null is return
        /// </summary>
        [Fact]
        public async void GivenRepositoryReturnsNull_WhenGetHotelsIsCalled_ThenNullIsReturned()
        {
            // Given
            var destinationId = 279;
            var nights = 2;
            var repository = new Mock<IWebBedsRepository>();

            repository.Setup(item => item.GetHotels(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync((List<FindAPIJsonObject>)null);

            var hotelService = new HotelService(repository.Object);

            // When
            var response = await hotelService.GetHotels(apiMethodName, destinationId, nights, authCode);

            // Then
            Assert.True(!response.HotelList.Any());
        }

        /// <summary>
        /// Returns data when GetHotel is called then null is return
        /// </summary>
        [Fact]
        public async void GivenRepositoryReturnsData_WhenGetHotelsIsCalled_ThenDataIsReturnedInTheView()
        {
            // Given
            var destinationId = 279;
            var nights = 2;
            var repository = new Mock<IWebBedsRepository>();
            var geoId = 1;
            var name = "TestData";
            var propId = 1;
            var rating = 5;
            var expectedResponse = new List<FindAPIJsonObject>
            {
                new FindAPIJsonObject
                {
                    hotel = new Repository.Entity.Hotel
                    {
                        GeoId = geoId,
                        Name = name,
                        PropertyID = propId,
                        Rating = rating
                    },
                    rates = new List<Repository.Entity.Rate>
                    {
                        new Repository.Entity.Rate
                        {
                            RateType= "Test",
                            BoardType = "Test",
                            Value = 22
                        },

                        new Repository.Entity.Rate
                        {
                            RateType= "Test",
                            BoardType = "Test",
                            Value = 25
                        }
                    }
                }
            };
            repository.Setup(item => item.GetHotels(apiMethodName, destinationId, nights, authCode)).ReturnsAsync(expectedResponse);
            var hotelService = new HotelService(repository.Object);

            // When
            var response = await hotelService.GetHotels(apiMethodName, destinationId, nights, authCode);

            // Then
            Assert.True(response.HotelList.Count > 0);
        }
    }
}
