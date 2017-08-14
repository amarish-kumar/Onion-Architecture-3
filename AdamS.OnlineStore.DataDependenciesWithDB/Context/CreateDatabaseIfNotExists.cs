using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using AdamS.OnlineStore.DataDependenciesWithDB;
using AdamS.OnlineStore.DomainModel;

namespace AdamS.OnlineStore.DataDependenciesWithDB
{
    public class CreateDatabaseIfNotExists2 : CreateDatabaseIfNotExists<DemoContext>
    {


        protected override void Seed(DemoContext context)
        {
            Customer c1 = new Customer { CustomerId = 1, FirstName = "Adamdb", LastName = "Appledb" };
            Customer c2 = new Customer { CustomerId = 2, FirstName = "Braddb", LastName = "Banandadb" };
            Customer c3 = new Customer { CustomerId = 3, FirstName = "Craigdb", LastName = "Canarydb" };

            Customer c4 = new Customer { CustomerId = 4, FirstName = "luckydb", LastName = "kungfudb" };
            Customer c5 = new Customer { CustomerId = 5, FirstName = "jokerdb", LastName = "matrixdb" };

            context.Customers.Add(c1);
            context.Customers.Add(c2);
            context.Customers.Add(c3);

            context.Customers.Add(c4);
            context.Customers.Add(c5);

            Order o1 = new Order { OrderId = 1, Customer = c1, OrderTotal = 12.45M };
            Order o2 = new Order { OrderId = 2, Customer = c2, OrderTotal = 11.22M };

            context.Orders.Add( o1);
            context.Orders.Add(o2);

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
