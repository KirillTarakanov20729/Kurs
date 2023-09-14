using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BrandModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public BrandModel() { }
        public BrandModel(Brand p)
        {
            id = p.id;
            name = p.name;
        }
    }
}
