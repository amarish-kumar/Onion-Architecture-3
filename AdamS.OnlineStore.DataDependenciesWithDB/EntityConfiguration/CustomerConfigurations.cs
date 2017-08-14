using AdamS.OnlineStore.DomainModel;
using System.Data.Entity.ModelConfiguration;

namespace SSW.DataOnion.Sample.Data.Configurations
{
    public class CustomerConfigurations : EntityTypeConfiguration<Customer>
    {
        public CustomerConfigurations()
        {
            this.HasKey(m => m.CustomerId);
            this.Property(p => p.BirthDate).IsOptional();
            this.Property(p => p.Email).IsOptional();



        }
    }
}
