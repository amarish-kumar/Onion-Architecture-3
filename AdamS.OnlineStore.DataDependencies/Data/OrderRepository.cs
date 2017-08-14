using AdamS.OnlineStore.DomainModel;
using System.Collections.Generic;
using System.Linq;
using AdamS.OnlineStore.RepositoryInterfaces;
using System;

namespace AdamS.OnlineStore.DataDependencies
{
    public class OrderRepository : IOrderRepository
    {
        List<Order> _orders;

        public OrderRepository()
        {

         
            _orders = new List<Order>{
                new Order{OrderId=1, Customer= new Customer { CustomerId = 11, FirstName="raja11", LastName="bala11" } , OrderTotal = 12.45M}, 
                new Order{OrderId=2, Customer= new Customer { CustomerId = 12, FirstName="raja12", LastName="bala12" } , OrderTotal = 23.00M}, 
                new Order{OrderId=3,  Customer= new Customer { CustomerId = 13, FirstName="raja13", LastName="bala13" }, OrderTotal = 54.50M}, 
            };
        }

        public List<Order> Get()
        {
            return _orders.ToList();
        }

        public List<Order> Get(int customerId)
        {
            return _orders.Where(c => c.Customer.CustomerId == customerId).ToList();
        }
    }
}