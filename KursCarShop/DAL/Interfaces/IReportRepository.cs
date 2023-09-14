using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.Reports;

namespace DAL.Interfaces
{
    public interface IReportsRepository
    {
        List<CarsByPrice> CarsByPrices(int min, int max);
        List<CarsByHorse> CarsByHorse(int equipId);
    }
}
