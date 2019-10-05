using Autofac;
using FrancisStore.Data;
using FrancisStore.Repository.Bases;
using FrancisStore.Repository.UnitOfWorks;
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
            builder.RegisterType<FrancisStoreDbContext>().
                As<IFrancisStoreDbContext>()
                .InstancePerRequest();
            builder.RegisterType<UnitOfWork>()
                .AsImplementedInterfaces()
                .InstancePerRequest();
            //Register the type-mapping, it configures which class instance of generic class to instantiate for which generic interface.
            builder.RegisterGeneric(typeof(GenericRepository<>))
                .As(typeof(IGenericRepository<>))
                .InstancePerRequest();
            //Register the type-mapping, it configures which class end with "Repository" to instantiate for which interface implemented by itself.
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly())
                .Where(type => type.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            base.Load(builder);
        }
    }
}
