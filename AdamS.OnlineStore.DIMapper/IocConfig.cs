using AdamS.OnlineStore.BusinessDependencies;
using AdamS.OnlineStore.BusinessInterfaces;
using AdamS.OnlineStore.DataDependencies;
using AdamS.OnlineStore.DomainModel;
using AdamS.OnlineStore.RepositoryInterfaces;
using Autofac;


namespace AdamS.OnlineStore.DIMapper
{
    public class BusinessRegistry : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<EmailSender>().As<INotificationProvider>().InstancePerRequest();
            builder.RegisterType<FileSystemLogger>().As<ILogger>().InstancePerRequest();
        }
    }

    public class RepositoryRegistry : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           // builder.RegisterType<AdamS.OnlineStore.DataDependencies.CustomerRepository>().As<ICustomerRepository>().SingleInstance();
           // builder.RegisterType<AdamS.OnlineStore.DataDependencies.OrderRepository>().As<IOrderRepository>().SingleInstance();

            builder.RegisterType<AdamS.OnlineStore.DataDependenciesWithDB.CustomerRepository>().As<ICustomerRepository>().SingleInstance();
            builder.RegisterType<AdamS.OnlineStore.DataDependenciesWithDB.OrderRepository>().As<IOrderRepository>().SingleInstance();

        }
    }
}