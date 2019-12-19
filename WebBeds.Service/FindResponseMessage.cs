namespace WebBeds.Service
{
    using System.Collections.Generic;

    /// <summary>
    /// This is the actual response message class returned to UI
    /// </summary>
    public class FindResponseMessage
    {
        /// <summary>
        /// List of Hotel fetched from API
        /// </summary>
        public List<HotelDetails> HotelList { get; set; }
        public FindResponseMessage()
        {
            HotelList = new List<HotelDetails>();
        }
    }
}
