namespace WebBeds.Repository
{
    using System.Collections.Generic;
    using WebBeds.Repository.Entity;

    public class FindAPIJsonObject
    {
        /// <summary>
        /// Hotel model
        /// </summary>
        public Hotel hotel { get; set; }
        /// <summary>
        /// List of hotel rate model
        /// </summary>
        public List<Rate> rates { get; set; }
    }
}
