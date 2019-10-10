using Autofac;
using FrancisStore.Service.Shopping.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Service
{
    public class FrancisStoreServiceModule : Autofac.Module
    {
        public FrancisStoreServiceModule() { }

        protected override void Load(ContainerBuilder builder)
        {
            //Register the type-mapping, it configures which class end with "Service" to instantiate for which interface implemented by itself.
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly())
                .Where(type => type.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerRequest();
            base.Load(builder);
        }
    }
}
