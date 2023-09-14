using BLL;
using BLL.Interfaces;
using Ninject.Modules;

namespace KursCarShop.utils
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IAddCarService>().To<AddCarService>();
            Bind<IReportService>().To<ReportsService>();
            Bind<IDbCrud>().To<DbDataOperations>();
        }
    }
}
