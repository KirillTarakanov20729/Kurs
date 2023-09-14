using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ModelModel
    {
        public int id { get; set; }
        public int brand_id { get; set; }
        public string name { get; set; }

        public BrandModel Brand { get; set; }
        public ModelModel() { }
        public ModelModel(Model p)
        {
            id = p.id;
            brand_id = p.brand_id;
            name = p.name;
        }

        public string DisplayString
        {
            get { return $" {Brand.name.Trim()} {name.Trim()}"; }
        }
    }
}
