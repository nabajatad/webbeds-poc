namespace WebBeds.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WebBeds.Repository.Entity;

    public class FindAPIJsonObject
    {
        public Hotel hotel { get; set; }
        public List<Rate> rates { get; set; }
    }
}
