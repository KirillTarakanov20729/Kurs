using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class EquipmentModel
    {
        public int id { get; set; }
        public int model_id { get; set; }
        public int horsepower { get; set; }
        public double engine_capacity { get; set; }
        public string transmission { get; set; }

        public ModelModel Model { get; set; }
        public EquipmentModel() { }
        public EquipmentModel(Equipment p)
        {
            id = p.id;
            model_id = p.model_id;
            horsepower = p.horsepower;
            engine_capacity = p.engine_capacity;
            transmission = p.transmission;
        }

        public string DisplayString
        {
            get { return $"{Model.Brand.name.Trim()} {Model.name.Trim()} ({horsepower} л.с., объем {engine_capacity} литра, коробка {transmission.Trim()})"; }
        }

        public string DisplayCapacity
        {
            get { return $"{engine_capacity} литра"; }
        }
    }
}
