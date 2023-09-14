using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDbRepos
    {
        IRepository<Car> Cars { get; }
        IRepository<Order> Orders { get; }
        IRepository<Equipment> Equipments { get; }
        IRepository<Model> Models { get; }
        IRepository<Brand> Brands { get; }
        IRepository<Client> Clients { get; }
        IRepository<Employee> Employees { get; }
        IRepository<User> Users { get; }
        IRepository<Type> Types { get; }
        IReportsRepository Reports { get; }
        int Save();
    }
}
