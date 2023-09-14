using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ClientModel
    {
        public int id { get; set; }

        public int user_id { get; set; }

        public string FIO { get; set; }
        public string phone { get; set; }
        public UserModel User { get; set; }

        public ClientModel() { }
        public ClientModel(Client p)
        {
            id = p.id;
            user_id = p.user_id;
            phone = p.phone;
            FIO = p.FIO;
        }
    }
}
