namespace WebBeds.Service
{
    using System.Threading.Tasks;

    public interface IHotelService
    {
        /// <summary>
        /// Find the Response Message
        /// </summary>
        /// <param name="apiMethodName"></param>
        /// <param name="destinationId"></param>
        /// <param name="nights"></param>
        /// <param name="authCode"></param>
        /// <returns>Response message about the hotel</returns>
        Task<FindResponseMessage> GetHotels(string apiMethodName, int destinationId, int nights, string authCode);
    }
}
