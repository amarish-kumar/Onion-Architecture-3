using AdamS.OnlineStore.DataDependenciesWithDB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace AdamS.OnlineStore.DataDependenciesWithDB
{
    public class DemoContextFactory : IDbContextFactory<DemoContext>
    {

        static bool _hasSetInitializer = false;
        string _connectionstring = string.Empty;
        public DemoContextFactory(string connectionstring)
        {
            _connectionstring = connectionstring;
        }
        public DemoContextFactory()
        {
            
        }
        public DemoContext Create()
        {

            if (!_hasSetInitializer)
            {              
                Database.SetInitializer<DemoContext>(new CreateDatabaseIfNotExists<DemoContext>());             
                _hasSetInitializer = true;
            }
            DemoContext dc;
            if(_connectionstring.Trim().Length>0)
            {
                dc = new DemoContext(_connectionstring);
            }
            else
            {
                dc = new DemoContext();
            }
          
          
                return dc;
        }

       
    }
}
