using System.Collections.Generic;
using AdamS.OnlineStore.DomainModel;

namespace AdamS.OnlineStore.RepositoryInterfaces
{
    public interface IOrderRepository
    {
        List<Order> Get();

        List<Order> Get(int orderId);
    }
}