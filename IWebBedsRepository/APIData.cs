namespace WebBeds.Repository
{
    using System.Collections.Generic;

    public class APIData
    {
        public List<HotelDetails> Hotellist { get; set; }

        public APIData()
        {
            Hotellist = new List<HotelDetails>();
        }

        /// <summary>
        /// Details of hotel
        /// </summary>
        public class HotelDetails
        {
            public string BoardType { get; set; }
            public string HotelName { get; set; }
            public string RateType { get; set; }
            public double BasePrice { get; set; }
            public double ActualPrice { get; set; }
        }
    }
}
