using AdamS.OnlineStore.DomainModel;
using AdamS.OnlineStore.RepositoryInterfaces;
using System.Collections.Generic;
using System.Linq;

namespace AdamS.OnlineStore.DataDependencies
{
    public class CustomerRepository : ICustomerRepository
    {
        List<Customer> _customers;

        public CustomerRepository()
        {
            _customers = new List<Customer>
            {
                new Customer {CustomerId = 1, FirstName = "Adam", LastName = "Apple" },
                new Customer {CustomerId = 2, FirstName = "Brad", LastName = "Banana"},
                new Customer {CustomerId = 3, FirstName = "Craig", LastName = "Canary"}
            };
        }

        public List<Customer> Get()
        {
            return _customers;
        }

        public Customer Get(int id)
        {
            return _customers.Single(cust => cust.CustomerId == id);
        }

        public Customer Add(Customer customer)
        {
            _customers.Add(customer);
            //todo: add Id field
            return customer;
        }

        public Customer Delete(int id)
        {
            Customer itemToRemove = _customers.SingleOrDefault(c => c.CustomerId == id);

            if (itemToRemove != null)
            {
                _customers.Remove(itemToRemove);
            }
            return itemToRemove;
        }
    }
}