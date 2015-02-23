using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jog.Common;
using Jog.Common.Security;
using Jog.Data;
using Jog.Data.Abstract;
using Jog.Data.Concrete;
using Ninject;
using Ninject.Web.Common;

namespace Jog.Web.Api
{
    public class NinjectConfigurator
    {
        public void Configure(IKernel container)
        {
            AddBindings(container);
        }

        public void AddBindings(IKernel container)
        {
            ConfigureUserSession(container);

            container.Bind<IDateTimeProvider>().To<DateTimeProvider>().InSingletonScope();
        }

        private void ConfigureUserSession(IKernel container)
        {
            var userSession = new UserSession();

            container.Bind<IJogRepo>().To<JogRepo>().InSingletonScope();
            container.Bind<IJogContext>().To<JogContext>().InSingletonScope();

            container.Bind<IUserSession>().ToConstant(userSession).InSingletonScope();
            container.Bind<IWebUserSession>().ToConstant(userSession).InSingletonScope();
        }
    }
}