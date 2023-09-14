using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Reports
    {
        public class CarsByPrice
        {
            public int Price { get; set; }
            public string Colour { get; set; }
            public bool Availability { get; set; }
        }

        public class CarsByHorse
        {
            public int Price { get; set; }
            public string Colour { get; set; }
            public bool Availability { get; set; }
        }
    }
}
