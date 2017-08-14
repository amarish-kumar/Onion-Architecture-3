using AdamS.OnlineStore.DomainModel;
using System.Collections.Generic;
using System.Linq;
using AdamS.OnlineStore.RepositoryInterfaces;
using System;
using System.Data.Entity;

namespace AdamS.OnlineStore.DataDependenciesWithDB
{
    public class OrderRepository : IOrderRepository
    {
        List<Order> _orders;
            

        public List<Order> Get()
        {
            using (var context = new DemoContextFactory().Create())
            {
                
                _orders = context.Orders.Include(a => a.Customer).ToList();
            }
            return _orders;
        }

        public List<Order> Get(int customerId)
        {

            using (var context = new DemoContextFactory().Create())
            {
                _orders = context.Orders.ToList();
                return _orders.Where(c => c.Customer.CustomerId == customerId).ToList();
            }          
          
        }
    }
}