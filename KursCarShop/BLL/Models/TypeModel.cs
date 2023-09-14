using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class TypeModel
    {
        public int id { get; set; }

        public string type { get; set; }

        public TypeModel() { }

        public TypeModel(DAL.Type p) 
        {
            id = p.id;
            type = p.type1;
        }
    }
}
