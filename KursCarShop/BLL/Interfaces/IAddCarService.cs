using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAddCarService
    {
        //Создает или изменяет существующий заказ
        void AddCar(CarModel car);
    }
}
