using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdamS.OnlineStore.DomainModel;

namespace AdamS.OnlineStore.DataDependenciesWithDB
{
    public class DemoContext : DbContext
    {

       
        public DemoContext(string connectionStringName)  : base(connectionStringName)
        {
            this.Configuration.LazyLoadingEnabled = true;
            Database.SetInitializer(new CreateDatabaseIfNotExists2());

        }

        
        public DemoContext() : base("name=DbConnection")
        {
            this.Configuration.LazyLoadingEnabled = true;
            Database.SetInitializer(new CreateDatabaseIfNotExists2());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Assembly);
        }


        public IDbSet<Customer> Customers { get; set; }

        public IDbSet<Order> Orders { get; set; }
           


    }
}
