using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class UserModel
    {
        public int id { get; set; }

        public int type_id { get; set; }

        public string email { get; set; }
        public string password { get; set; }
        public TypeModel Type { get; set; }
        public UserModel() { }
        public UserModel(User p)
        {
            id = p.id;
            type_id = p.type_id;
            email = p.email;
            password = p.password;
        }

        public string DisplayString
        {
            get { return $"{email} {password}"; }
        }
    }
}
