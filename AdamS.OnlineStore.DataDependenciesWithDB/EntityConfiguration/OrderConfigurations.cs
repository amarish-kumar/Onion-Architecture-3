using System.Data.Entity.ModelConfiguration;
using AdamS.OnlineStore.DomainModel;

namespace SSW.DataOnion.Sample.Data.Configurations
{
    public class OrderConfigurations : EntityTypeConfiguration<Order>
    {
        public OrderConfigurations()
        {
            HasKey(m => m.OrderId).HasRequired(c => c.Customer).WithMany(a=>a.Orders);

           
        }
    }
}
