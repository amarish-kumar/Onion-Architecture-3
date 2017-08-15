using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdamS.OnlineStore.DomainModel;
using System.Reflection;
using System.IO;
using System.Diagnostics;

namespace AdamS.OnlineStore.DataDependenciesWithDB
{
    public class DemoContext : DbContext
    {

       
        public DemoContext(string connectionStringName)  : base(connectionStringName)
        {
            LoadConfig();
        }

        
        public DemoContext() : base("name=DbConnection")
        {
                    
            LoadConfig();
        }

    

        public void LoadConfig()
        {
            this.Configuration.LazyLoadingEnabled = true;
            Database.SetInitializer(new CreateDatabaseIfNotExists2());



            //// Get calling method name
            ////when running from nunit, dbcontext cudnt create database, by defaults it goes for c:program files\sqlserver
            //// no permision there, by shortcut , we are writing overwriting path here

            //// bool setDbPathOnlyCalledFromTest = false;
            //StackTrace stackTrace = new StackTrace();
            //string caller = (stackTrace.GetFrame(4)?.GetMethod()).Name;
            //if (caller.Contains("CustomerRepositoryTest"))
            //{
            //    string path = string.Empty;
            //    // path =  System.IO.Directory.GetCurrentDirectory();
            //    //C:\ProgramData
            //    path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);//C:\ProgramData
            //    //path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Locati‌​on);
            //    AppDomain.CurrentDomain.SetData("DataDirectory", path);
            //}
           
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Assembly);
        }


        public IDbSet<Customer> Customers { get; set; }

        public IDbSet<Order> Orders { get; set; }
           


    }
}
