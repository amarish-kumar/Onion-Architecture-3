using AdamS.OnlineStore.DomainModel;
using AdamS.OnlineStore.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace AdamS.OnlineStore.DataDependenciesWithDB
{
    public class CustomerRepository : ICustomerRepository
    {
        List<Customer> _customers;
        string connectionstring;
        public CustomerRepository()
        {
          
        }

        public List<Customer> Get()
        {
            using (var context = new DemoContextFactory().Create())
            {
                _customers = context.Customers.ToList();
            }
            return _customers;
        }

        public Customer Get(int id)
        {
            using (var context = new DemoContextFactory().Create())
            {
                _customers = context.Customers.ToList();
            }
            return _customers.Single(cust => cust.CustomerId == id);
        }

        public Customer Add(Customer customer)
        {
            using (var context = new DemoContextFactory().Create())
            {
                _customers.Add(customer);
                context.SaveChanges();
            }
         
            //todo: add Id field
            return customer;
        }

        public Customer Delete(int id)
        {
            Customer itemToRemove;
            using (var context = new DemoContextFactory().Create())
            {
                _customers = context.Customers.ToList();

                itemToRemove = _customers.SingleOrDefault(c => c.CustomerId == id);

                if (itemToRemove != null)
                {
                    //_customers.Remove(itemToRemove);
                    context.Customers.Remove(itemToRemove);
                    context.SaveChanges();
                }

            }
            return itemToRemove;
        }
    }
}