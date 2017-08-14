using System.Collections.Generic;
using AdamS.OnlineStore.DomainModel;

namespace AdamS.OnlineStore.RepositoryInterfaces
{
    public interface ICustomerRepository
    {
        List<Customer> Get();
        Customer Get(int id);
        Customer Add(Customer customer);
        Customer Delete(int id);
    }
}