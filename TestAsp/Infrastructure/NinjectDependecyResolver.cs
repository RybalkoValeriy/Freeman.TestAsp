using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Ninject.Parameters;
using Ninject.Syntax;
using System.Web.Mvc;
using TestAsp.Models;

namespace TestAsp.Infrastructure
{
    public class NinjectDependecyResolver : IDependencyResolver
    {
        IKernel kernel;

        public NinjectDependecyResolver()
        {
            kernel = new StandardKernel();
            Bindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);// kernel.get<interface>(); 
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType); // kernek.getll<interface> - несколько связок
        }

        private void Bindings()
        {
            kernel.Bind<IValueProductCalculator>().To<LinqValueCalculator>();
            kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithPropertyValue("DiscountSize", 50m);
            kernel.Bind<IDiscountHelper>().To<FlexibleDiscountHelper>().WhenInjectedInto<LinqValueCalculator>();
        }
    }
}