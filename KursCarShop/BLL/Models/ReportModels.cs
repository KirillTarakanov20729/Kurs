using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class ReportModels
    {
        public class CarsByPrice
        {
         
            public int Price { get; set; }
            public string Colour { get; set; }

            public bool Availability { get; set; }

            public string AvailabilityText
            {
                get { return Availability ? "Есть в наличии" : "Нет в наличии"; }
            }

        }

        public class CarsByHorse
        {
     
            public int Price { get; set; }
            public string Colour { get; set; }

            public bool Availability { get; set; }

            public string AvailabilityText
            {
                get { return Availability ? "Есть в наличии" : "Нет в наличии"; }
            }
        }
    }
}
