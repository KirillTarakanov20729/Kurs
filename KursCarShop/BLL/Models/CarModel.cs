using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class CarModel
    {
        public int id { get; set; }
        public int equipment_id { get; set; }
        public int price { get; set; }
        public string colour { get; set; }
        public bool availability { get; set; }

        public EquipmentModel Equipment { get; set; }

        public CarModel() { }
        public CarModel(Car p)
        {
            id = p.id;
            equipment_id = p.equipment_id;
            price = p.price;
            colour = p.colour;
            availability = p.availability;
        }

        public string AvailabilityText
        {
            get { return availability ? "Есть в наличии" : "Нет в наличии"; }
        }
        public string DisplayString
        {
            get { return $"{Equipment.Model.Brand.name.Trim()} {Equipment.Model.name.Trim()} ({Equipment.horsepower} л.с., объем {Equipment.engine_capacity} литра, коробка {Equipment.transmission.Trim()})"; }
        }
    }
}
