using Autofac;
using FrancisStore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Repository
{
    public class FrancisStoreRepositoryModule: Module
    {
        public FrancisStoreRepositoryModule() {}

        protected override void Load(ContainerBuilder builder)
        {
            
            //Register the type-mapping, it configures which class to instantiate for which interface or base class
            builder.RegisterType<FrancisStoreDbContext>().As<IFrancisStoreDbContext>().InstancePerRequest();
            //Register the type-mapping, it configures which class end with "Repository" to instantiate for which interface implemented by itself.
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly())
                .Where(type => type.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

            base.Load(builder);
        }
    }
}
