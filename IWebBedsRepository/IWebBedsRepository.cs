namespace WebBeds.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IWebBedsRepository
    {
        /// <summary>
        /// List of API JSON
        /// </summary>
        /// <param name="apiMethodName">This is the API method name</param>
        /// <param name="destinationId">This is the destination id where the hotels need to be fetched</param>
        /// <param name="nights">This is the number of nights for the travel</param>
        /// <param name="authCode">This is the authentication code to access the API</param>
        /// <returns>List of Hotels</returns>
        Task<List<FindAPIJsonObject>> GetHotels(string apiMethodName, int destinationId, int nights, string authCode);
    }
}
