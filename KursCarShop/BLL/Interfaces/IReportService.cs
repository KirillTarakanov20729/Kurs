using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLL.Models.ReportModels;

namespace BLL.Interfaces
{
    public interface IReportService
    {
        /// <summary>
        /// выполнить ХП - отчет по заказам за месяц
        /// </summary>
        List<CarsByPrice> CarsByPrices(int min, int max);
        /// <summary>
        /// Количество заказов
        /// </summary>
        List<CarsByHorse> CarsByHorse(int equipId);
    }
}
