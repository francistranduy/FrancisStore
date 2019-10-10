using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrancisStore.Identity
{
    public class FrancisStoreIdentityModule : Autofac.Module
    {
        public FrancisStoreIdentityModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterControllers(this.GetType().Assembly);

            //Register the type-mapping, it configures which class end with "Service" to instantiate for which interface implemented by itself.
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly())
                .Where(type => type.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerRequest();
            base.Load(builder);
        }
    }
}