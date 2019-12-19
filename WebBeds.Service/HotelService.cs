namespace WebBeds.Service
{
    using System.Linq;
    using System.Threading.Tasks;
    using WebBeds.Repository;

    public class HotelService : IHotelService
    {
        private IWebBedsRepository repository;

        /// <summary>
        /// Constructor of HotelService
        /// </summary>
        /// <param name="repo"></param>
        public HotelService(IWebBedsRepository repo)
        {
            repository = repo;
        }

        /// <summary>
        /// Get all the hotels
        /// </summary>
        /// <returns>Response message about searched hotel</returns>
        public async Task<FindResponseMessage> GetHotels(string apiMethodName, int destinationId, int nights, string authCode)
        {
            //Calling the Repository Method to fetch Hotel details
            var result = await repository.GetHotels(apiMethodName, destinationId, nights, authCode);

            FindResponseMessage responseMessage = new FindResponseMessage();
            if (result != null && result.Any())
            {
                foreach (var hotel in result)
                {
                    foreach (var rate in hotel.rates)
                    {
                        responseMessage.HotelList.Add(new HotelDetails
                        {
                            BoardType = rate.BoardType,
                            HotelName = hotel.hotel.Name,
                            BasePrice = rate.Value,
                            ActualPrice = rate.RateType == "PerNight" ? rate.Value * nights : rate.Value,
                            RateType = rate.RateType
                        });
                    }
                }
            }
            return responseMessage;
        }
    }
}