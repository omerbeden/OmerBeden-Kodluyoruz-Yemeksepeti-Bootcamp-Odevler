using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Part8.Data.Models.Abstract;

namespace Part8.Data.Models.Derivered
{
    public class HotelInfo:Resource
    {
        public string Title { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public HotelAdress Location { get; set; }

    }
}
