namespace WebBeds.Repository
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class WebBedsRepository : IWebBedsRepository
    {
        private string apiURI;

        /// <summary>
        /// Constructor of WebBedsRepository
        /// </summary>
        /// <param name="apiURI"></param>
        public WebBedsRepository(string apiURI)
        {
            this.apiURI = apiURI;
        }

        /// <summary>
        /// Get the list of Hotels
        /// </summary>
        /// <param name="apiMethodName">This is the API method name</param>
        /// <param name="destinationId">This is the destination id where the hotels need to be fetched</param>
        /// <param name="nights">This is the number of nights for the travel</param>
        /// <param name="authCode">This is the authentication code to access the API</param>
        /// <returns>List of Hotels</returns>
        public async Task<List<FindAPIJsonObject>> GetHotels(string apiMethodName, int destinationId, int nights, string authCode)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var result = new List<FindAPIJsonObject>();
                    client.BaseAddress = new Uri(apiURI);
                    var requestUri = apiMethodName + $"?destinationId={destinationId}&nights={nights}&code={authCode}";
                    using (var response = await client.GetAsync(requestUri))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var jsonString = await response.Content.ReadAsStringAsync();

                            result = JsonConvert.DeserializeObject<List<FindAPIJsonObject>>(jsonString);
                        }
                        else
                        {
                            throw new Exception("API Exception Occurred. Try with different query or contact support.");
                        }
                        return result;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
