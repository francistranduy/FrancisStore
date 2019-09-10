using Autofac;
using FrancisStore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Repository
{
    public class FrancisStoreDbModule: Module
    {
        public FrancisStoreDbModule() {}

        protected override void Load(ContainerBuilder builder)
        {
            //Register the type-mapping, it configures which class to instantiate for which interface or base class
            builder.RegisterType<FrancisStoreDbContext>().As<IFrancisStoreDbContext>().InstancePerRequest();
            builder.RegisterType<FrancisStoreRepository>().As<IFrancisStoreRepository>().InstancePerRequest();
            base.Load(builder);
        }
    }
}
