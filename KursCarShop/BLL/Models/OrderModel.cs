using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class OrderModel
    {
        public int id { get; set; }
        public int client_id { get; set; }
        public int employee_id { get; set; }
        public int car_id { get; set; }
        public bool status { get; set; }
        public DateTime date { get; set; }

        public ClientModel Client { get; set; }
        public EmployeeModel Employee { get; set; }
        public CarModel Car { get; set; }

        public OrderModel() { }

        public OrderModel(Order p)
        {
            id = p.id;
            client_id = p.client_id;
            employee_id = p.employee_id;
            car_id = p.car_id;
            status = p.status;
            date = p.date;
        }

        public string StatusText
        {
            get { return status ? "Завершен" : "В процессе"; }
        }
        public string FormattedDate
        {
            get { return date.ToString("dd-MM-yyyy"); }
        }
    }
}
