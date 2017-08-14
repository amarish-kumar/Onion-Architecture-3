namespace AdamS.OnlineStore.DomainModel
{
    public class Order
    {
        public int OrderId { get; set; }
       
        public decimal OrderTotal { get; set; }
        public virtual Customer Customer { get; set; }
    }
}