using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoApplication.Repositories;
using DemoApplication.ViewModels;
using log4net;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using DemoApplication.Repositories;
using DemoApplication.ViewModels;
using log4net;
using Ninject;
using NUnit.Framework;


namespace DemoApplication.Tests
{
    class InMemoryRepositoryTests
    {
        private readonly StandardKernel _kernel;

        public InMemoryRepositoryTests()
        {

            _kernel = new StandardKernel();

            _kernel.Bind<ILog>().ToMethod(context => LogManager.GetLogger(context.Request.Target?.Member.DeclaringType?.FullName));
            _kernel.Bind<ObservableCollection<VehicleViewModel>>().ToSelf().InSingletonScope(); // one which is passed to dispatchers as well as mvm
            _kernel.Bind<IVehicleRepository>().To<SqLiteVehicleRepository>().InSingletonScope();
        }
    }
}
