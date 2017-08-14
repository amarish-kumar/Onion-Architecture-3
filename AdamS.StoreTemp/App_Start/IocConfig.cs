

using System.Web.Mvc;
using AdamS.OnlineStore.Models;
using AdamS.OnlineStore;
using AdamS.OnlineStore.Models;
using Autofac;
using Autofac.Integration.Mvc;
using AdamS.OnlineStore.DIMapper;

namespace AdamS.OnlineStore
{
    public class IoCConfig
    {
        public static void RegisterDependencies()
        {
            //Create the builder
            var builder = new ContainerBuilder();
            
            //Register all controllers for the assembly
            builder.RegisterControllers(typeof(MvcApplication).Assembly).InstancePerRequest();


            var assemblyContainingRegistries = typeof(BusinessRegistry).Assembly;
            builder.RegisterAssemblyModules(assemblyContainingRegistries);


            //Set the MVC dependency resolver to use Autofac
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

    }    

}